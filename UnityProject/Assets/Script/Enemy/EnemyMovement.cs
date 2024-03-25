using UnityEngine;
using UnityEngine.AI;

namespace Script.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float closeDistanceThreshold = 3f;

        private NavMeshAgent _agent;
        private Transform _player;
        private EnemySound _sound;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _agent = GetComponent<NavMeshAgent>();
            _sound = GetComponent<EnemySound>();
        }

        private void Update()
        {
            var position = _player.position;
            _agent.SetDestination(position);

            //ToDo Play Animation
            if (_sound)
            {
                var distanceToPlayer = Vector3.Distance(transform.position, position);
                if (distanceToPlayer < closeDistanceThreshold) _sound.PlayEnemyNearSound();
            }
        }
    }
}