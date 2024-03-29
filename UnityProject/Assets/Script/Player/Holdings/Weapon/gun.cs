using UnityEngine;

namespace Script.Player.Holdings.Weapon
{
    public class gun : MonoBehaviour
    {
        public Bullet bullet;
        public Transform bulletSpawnPoint;
        public GameObject arm;
        public AudioSource audioSource;
        public Animator gunAnimator;
        public ParticleSystem shootingParticles;

        private AmmunitionHandler _ammunitionHandler;
        private bool isShooting = false;

        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
        }

        private void Update()
        {
            if (Time.timeScale == 0) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartShooting();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                StopShooting();
            }
        }

        private void StartShooting()
        {
            if (!isShooting)
            {
                isShooting = true;
                gunAnimator.SetTrigger("Shoot"); 
                shootingParticles.Play();
                ShootBullet();
            }
        }

        private void StopShooting()
        {
            if (isShooting)
            {
                isShooting = false;
                gunAnimator.SetTrigger("Shoot"); 
                shootingParticles.Stop();
            }
        }

        private void ShootBullet()
        {
            var ammunition = _ammunitionHandler.Ammunition;
            if (ammunition > 0)
            {
                _ammunitionHandler.Ammunition = ammunition - 1;
                var newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                audioSource.Play();
                newBullet.ReadyToFly = true;
            }
            else
            {
                // Optionally stop shooting if out of ammunition
                StopShooting();
            }
        }

        private void LateUpdate()
        {
            var playerViewDirection = Camera.main.transform.forward;
            var targetRotation = Quaternion.LookRotation(playerViewDirection);
            bulletSpawnPoint.rotation = targetRotation;

            var playerViewEulerAngles = Camera.main.transform.eulerAngles.x;
            arm.transform.localEulerAngles = new Vector3(0F, -playerViewEulerAngles + 60, 0);
        }
    }
}
