using Script.Enemy;
using Script.UI;
using UnityEngine;

namespace Script.Player.Holdings.Weapon
{
    public class Bullet : MonoBehaviour
    {
        public float maxFlyTime = 5;
        private AmmunitionHandler _ammunitionHandler;
        public bool ReadyToFly { get; set; }

        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
        }

        private void Update()
        {
            if (maxFlyTime < 0)
            {
                Destroy(gameObject);
                return;
            }

            if (!ReadyToFly) return;

            transform.Translate(Vector3.forward * Time.deltaTime * _ammunitionHandler.BulletSpeed);
            maxFlyTime -= Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;

            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth == null) return;
            enemyHealth.Damage(_ammunitionHandler.BulletDamage);
            Destroy(gameObject);
        }
    }
}