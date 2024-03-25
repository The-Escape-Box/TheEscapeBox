using UnityEngine;

namespace Script.Player
{
    public class Pistol : MonoBehaviour
    {
        public Bullet bullet;
        public Transform bulletSpawnPoint;
        public GameObject arm;
        public AudioSource audioSource; // Reference to the assigned AudioSource component

        private AmmunitionHandler _ammunitionHandler; // Reference to the AmmunitionHandler script

        // Start is called before the first frame update
        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.timeScale == 0) return;

            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

            var ammunition = _ammunitionHandler.Ammunition;
            if (ammunition == 0) return;

            _ammunitionHandler.Ammunition = ammunition - 1;
            var newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            newBullet.ReadyToFly = true;

            // Play shooting sound via the AudioSource component

            if (audioSource != null) audioSource.Play(); // Assuming the AudioSource is set up to play the sound effect
        }

        // LateUpdate is called once per frame after Update
        private void LateUpdate()
        {
            // Get the forward direction of the camera
            var playerViewDirection = Camera.main.transform.forward;

            // Calculate the rotation needed to align the bullet spawn point with the player's view direction
            var targetRotation = Quaternion.LookRotation(playerViewDirection);
            bulletSpawnPoint.rotation = targetRotation;

            var playerViewEulerAngles = Camera.main.transform.eulerAngles.x;
            arm.transform.localEulerAngles = new Vector3(0F, -playerViewEulerAngles + 60, 0);
        }
    }
}