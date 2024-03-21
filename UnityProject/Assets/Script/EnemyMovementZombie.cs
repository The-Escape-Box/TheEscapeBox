using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Script
{
    public class EnemyMovementZombie : MonoBehaviour
    {
        public Transform player; // Public variable to assign the player in the editor
        private NavMeshAgent agent;
        private float _health = 5F;
        private BloodBankHandler _bloodBankHandler;
        
        public float moveRange = 1f; // Range at which the damage will be dealt

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _bloodBankHandler = BloodBankHandler.Instance;
        }

        void Update()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < moveRange)
            {
                agent.enabled = false;
                return;
            }
            agent.enabled = true;
            
            agent.destination = player.position;
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