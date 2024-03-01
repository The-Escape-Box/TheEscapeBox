using UnityEngine;

namespace Script
{
    public class Bullet : MonoBehaviour
    {
        public float maxFlyTime = 5;

        public bool ReadyToFly { get; set; }

        private AmmunitionHandler _ammunitionHandler;

        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
        }

        private void Update()
        {
            if (maxFlyTime < 0)
            {
                Destroy(gameObject);
            }

            if (!ReadyToFly) return;

            transform.Translate(Vector3.forward);
            maxFlyTime -= Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            
            DemonMovement enemyController = other.gameObject.GetComponent<DemonMovement>();
            if (enemyController != null)
            {
                enemyController.DealDamage(_ammunitionHandler.BulletDamage);
            }

            Destroy(gameObject);
        }

    }
}