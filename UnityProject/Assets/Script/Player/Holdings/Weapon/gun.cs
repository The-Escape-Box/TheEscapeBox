using System.Collections;
using Script.UI;
using UnityEngine;

namespace Script.Player.Holdings.Weapon
{
    public class Gun : MonoBehaviour
    {
        public Bullet bullet;
        public Transform bulletSpawnPoint;
        public GameObject arm;
        public AudioSource audioSource;
        public Animator gunAnimator;
        public ParticleSystem shootingParticles;

        private AmmunitionHandler _ammunitionHandler;
        private bool isShooting;

        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
            StartCoroutine(DelayedStopShooting(0.0F));
            audioSource.Stop();
        }

        private void Update()
        {
            if (Time.timeScale == 0) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartShooting();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                StartCoroutine(DelayedStopShooting(0.3f));
            }

            if (isShooting)
            {
                ShootBullet();
            }
        }

        private void LateUpdate()
        {
            var playerViewEulerAngles = Camera.main.transform.eulerAngles.x;
            arm.transform.localEulerAngles = new Vector3(0f, -playerViewEulerAngles + 60f, 0f);
            
            var playerViewDirection = Camera.main.transform.forward;
            bulletSpawnPoint.rotation = Quaternion.LookRotation(playerViewDirection);
        }

        private void StartShooting()
        {
            if (!isShooting)
            {
                isShooting = true;
                gunAnimator.SetTrigger("Shoot");
                shootingParticles.Play();
                if (!audioSource.isPlaying) // Check if the audio source is not already playing
                    audioSource.Play(); // Start playing audio only if it's not already playing
            }
        }

        private IEnumerator DelayedStopShooting(float delay)
        {
            if (isShooting)
            {
                isShooting = false;
                gunAnimator.SetTrigger("Shoot");
                shootingParticles.Stop();
            yield return new WaitForSeconds(delay); // Wait for the specified delay
                if (audioSource.isPlaying) // Stop playing audio only if it's currently playing
                    audioSource.Stop();
            }
        }

        private void ShootBullet()
        {
            var ammunition = _ammunitionHandler.Ammunition;
            if (ammunition > 0)
            {
                _ammunitionHandler.Ammunition = ammunition - 1;
                InstantiateBullet();
            }
            else
            {
                StartCoroutine(DelayedStopShooting(0.0f));
                gunAnimator.SetTrigger("StopShooting");
            }
        }

        private void InstantiateBullet()
        {
            var newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            newBullet.ReadyToFly = true;
        }
    }
}