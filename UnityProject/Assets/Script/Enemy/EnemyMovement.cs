using UnityEngine;
using UnityEngine.AI;

namespace Script.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float closeDistanceThreshold = 3F;
        [SerializeField] private float toCloseToMoveThreshold = 2F;

        private NavMeshAgent _agent;
        private Transform _player;
        private EnemySound _sound;
        private Animator _animator;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _agent = GetComponent<NavMeshAgent>();
            _sound = GetComponent<EnemySound>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var position = _player.position;
            var distanceToPlayer = Vector3.Distance(transform.position, position);
            _agent.SetDestination(position);

            if (_sound)
            {
                if (distanceToPlayer < closeDistanceThreshold) _sound.PlayEnemyNearSound();
            }
            
            if (distanceToPlayer < toCloseToMoveThreshold)
            {
                _animator.SetInteger("Control", 0);
                _agent.speed = 0;
            }
            else
            {
                _animator.SetInteger("Control", 1);
                _agent.speed = 3;
            }
            
        }
    }
}