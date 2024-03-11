using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class EnemyMovementZombie : MonoBehaviour
    {
        public Transform player; // Public variable to assign the player in the editor
        private NavMeshAgent agent;
        private float _health = 5F;
        private BloodBankHandler _bloodBankHandler;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _bloodBankHandler = BloodBankHandler.Instance;
        }

        void Update()
        {
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