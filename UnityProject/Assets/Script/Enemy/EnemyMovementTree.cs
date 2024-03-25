using Script.Shop;
using UnityEngine;
using UnityEngine.AI;

namespace Script.Enemy
{
    public class EnemyMovementTree : MonoBehaviour
    {
        public Transform player; // Public variable to assign the player in the editor
        private NavMeshAgent agent;
        private Animator anim;
        private float _health = 5F;
        public float closeDistanceThreshold = 3f; // Distance threshold for playing sound effect
        public AudioSource audioSource; // Reference to the assigned AudioSource component

        private BloodBankHandler _bloodBankHandler;

        int hIdles;
        int hAngry;
        int hAttack;
        int hGrabs;

        public float attackDistance = 5f; // Distance at which the demon attacks
        public float grabDistance = 2f;   // Distance at which the demon grabs the player

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>(); // Assign the AudioSource component

            // Set up hash IDs for animation states
            hIdles = Animator.StringToHash("Idles");
            hAngry = Animator.StringToHash("Angry");
            hAttack = Animator.StringToHash("Attack");
            hGrabs = Animator.StringToHash("Grabs");

            // Set up global handler
            _bloodBankHandler = BloodBankHandler.Instance;
        }

        void Update()
        {
            // Check if the agent is stopped (grabbing player), if so, return
            if (agent.isStopped)
                return;

            // Set the destination of the NavMeshAgent to the player's position
            agent.SetDestination(player.position);

            // Check the distance between enemy and player
            var distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < closeDistanceThreshold)
            {
                // Play the sound effect if player is too close
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.Play(); // Assuming the AudioSource is set up to play the sound effect
                }
            }

            // Determine which animation to play based on distance
            if (distanceToPlayer <= attackDistance)
            {
                // Player is close enough to attack
                Attack();
            }
            else if (distanceToPlayer <= grabDistance)
            {
                // Player is too close, use Grabs animation
                Grabs();
            }
            else
            {
                // Player is far, return to idle state
                UpdateAnimation(true); // Start moving animation
            }
        }

        void UpdateAnimation(bool isMoving)
        {
            // Set animation parameters based on movement
            anim.SetBool(hIdles, !isMoving);
            anim.SetBool(hAngry, false); // Assuming Angry animation is not movement-based
            anim.SetBool(hAttack, false); // Assuming Attack animation is not movement-based
            anim.SetBool(hGrabs, false); // Assuming Grabs animation is not movement-based
        }

        void Attack()
        {
            // Trigger attack animation
            UpdateAnimation(false); // Stop any movement animation
            anim.SetBool(hAttack, true);
        }

        void Grabs()
        {
            // Trigger grabs animation
            UpdateAnimation(false); // Stop any movement animation
            anim.SetBool(hGrabs, true);
        }

        public void DealDamage(float damage)
        {
            _health -= damage;
            _bloodBankHandler.Blood += 1;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
