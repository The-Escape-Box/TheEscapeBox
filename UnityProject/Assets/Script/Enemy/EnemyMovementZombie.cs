using Script.Shop;
using UnityEngine;
using UnityEngine.AI;

namespace Script.Enemy
{
    public class EnemyMovementZombie : MonoBehaviour
    {
        public Transform player; // Public variable to assign the player in the editor
        public float closeDistanceThreshold = 3f; // Distance threshold for playing sound effect
        public AudioSource audioSource; // Reference to the assigned AudioSource component
        public float grabDistance = 2f; // Distance at which the demon grabs the player
        private BloodBankHandler _bloodBankHandler;
        private float _health = 5F;
        private NavMeshAgent agent;


        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _bloodBankHandler = BloodBankHandler.Instance;
            audioSource = GetComponent<AudioSource>(); // Assign the AudioSource component
        }

        private void Update()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < grabDistance)
            {
                agent.enabled = false;
            }
            else
            {
                agent.enabled = true;
                agent.destination = player.position;
            }

            // Check the distance between enemy and player
            if (Vector3.Distance(transform.position, player.position) < closeDistanceThreshold)
                // Play the sound effect if player is too close
                if (audioSource != null && !audioSource.isPlaying)
                    audioSource.Play(); // Assuming the AudioSource is set up to play the sound effect
        }

        public void DealDamage(float damage)
        {
            _health -= damage;
            _bloodBankHandler.Blood += 1;

            if (_health <= 0) Destroy(gameObject);
        }
    }
}