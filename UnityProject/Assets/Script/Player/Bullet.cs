using Script.Enemy;
using UnityEngine;

namespace Script.Player
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

            // Check if the collided object is an EnemyMovementTree
            var enemyControllerTree = other.gameObject.GetComponent<EnemyMovementTree>();
            if (enemyControllerTree != null)
            {
                enemyControllerTree.DealDamage(_ammunitionHandler.BulletDamage);
                Destroy(gameObject);
                return; // Exit early to avoid unnecessary checks
            }

            // Check if the collided object is an EnemyMovementZombie
            var enemyControllerZombie = other.gameObject.GetComponent<EnemyMovementZombie>();
            if (enemyControllerZombie != null)
            {
                enemyControllerZombie.DealDamage(_ammunitionHandler.BulletDamage);
                Destroy(gameObject);
            }
        }
    }
}