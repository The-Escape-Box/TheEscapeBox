using Script.Player;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private float damageInterval = 5f;
        [SerializeField] private float attackRange = 2f;

        private float _lastDamageTime;
        private GameObject _player;
        private PlayerHealthHandler _playerHealthHandler;
        private EnemySound _sound;
        private Animator _animator;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealthHandler = PlayerHealthHandler.Instance; 

            _animator = GetComponent<Animator>();
            _sound = GetComponent<EnemySound>();
        }

        private void Update()
        {
            if (Time.time - _lastDamageTime > damageInterval) DealDamageToPlayer();
        }

        private void DealDamageToPlayer()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
            if (distanceToPlayer > attackRange) return;

            _animator.SetTrigger("Attack");
            
            if (_sound) _sound.PlayAttackSound();

            _playerHealthHandler.DealDamage(damage);
            _lastDamageTime = Time.time;
        }
    }
}