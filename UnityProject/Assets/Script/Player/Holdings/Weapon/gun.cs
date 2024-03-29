using UnityEngine;

namespace Script.Player.Holdings.Weapon
{
    public class gun : MonoBehaviour
    {
        public Bullet bullet;
        public Transform bulletSpawnPoint;
        public GameObject arm;
        public AudioSource audioSource; // Reference to the assigned AudioSource component
        public Animator gunAnimator; // Reference to the Animator component
        public ParticleSystem shootingParticles; // Reference to the Particle System

        private AmmunitionHandler _ammunitionHandler; // Reference to the AmmunitionHandler script

        private bool isShooting = false; // Flag to track if shooting is in progress

        // Start is called before the first frame update
        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
        }

        // Update is called once per frame
    

private void Update()
{
    if (Time.timeScale == 0) return;

    // Check if shooting action is initiated
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
        isShooting = true; // Start shooting
        print("is shooting:" + isShooting);
        // Play the particle system
        shootingParticles.Play();
    }
    
    // Check if shooting action is stopped
    if (Input.GetKeyUp(KeyCode.Mouse0))
    {
        isShooting = false; // Stop shooting
        print("is shooting:" + isShooting);
        shootingParticles.Stop(); // Stop particle system when shooting stops
    }

    // Check if shooting is in progress
    if (isShooting)
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
            // Stop particle system if out of ammunition
            shootingParticles.Stop();
        }
    }
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