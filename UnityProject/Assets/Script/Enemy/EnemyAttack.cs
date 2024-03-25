using Script.Player;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private float damageInterval = 1f;
        [SerializeField] private float attackRange = 2f;

        private float _lastDamageTime;
        private GameObject _player;
        private PlayerHealthHandler _playerHealthHandler;
        private EnemySound _sound;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealthHandler = PlayerHealthHandler.Instance;

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

            //ToDo Play Animation
            if (_sound) _sound.PlayAttackSound();

            _playerHealthHandler.DealDamage(damage);
            _lastDamageTime = Time.time;
        }
    }
}