using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Script
{
    public class Pistol : MonoBehaviour
    {
        public Bullet bullet;
        public AudioClip shootingSound; // Sound clip for shooting
        public GameObject hand;
        public GameObject arm;

        private Transform _bulletSpawnPoint;
        private AudioSource _audioSource; // Reference to the AudioSource component

        // Start is called before the first frame update
        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
            _bulletSpawnPoint = transform.Find("BulletSpawnPoint").transform;
            _audioSource = GetComponent<AudioSource>(); // Get reference to AudioSource component
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.timeScale == 0)
            {
                return;
            }

            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

            var ammunition = _ammunitionHandler.Ammunition;
            if (ammunition == 0)
            {
                return;
            }

            _ammunitionHandler.Ammunition = ammunition - 1;
            var newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            newBullet.ReadyToFly = true;

            // Play shooting sound
            if (shootingSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(shootingSound);
            }
        }

        // LateUpdate is called once per frame after Update
        private void LateUpdate()
        {
            // Example code using Euler angles
            Vector3 playerViewEulerAngles = Camera.main.transform.eulerAngles;
            float x = playerViewEulerAngles.x;
            bulletSpawnPoint.localEulerAngles = new Vector3(x, 180f, 0f);
            hand.transform.localEulerAngles = new Vector3(90F, -x - 20, 0);
            arm.transform.localEulerAngles = new Vector3(0F, -x + 60, 10F);
        }
    }
}
