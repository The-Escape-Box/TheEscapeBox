using Script.UIOverlays.Shop;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float health = 5F;

        private BloodBankHandler _bloodBankHandler;
        private EnemySound _sound;

        private void Start()
        {
            _bloodBankHandler = BloodBankHandler.Instance;
            _sound = GetComponent<EnemySound>();
        }

        public void Damage(float damage)
        {
            health -= damage;
            _bloodBankHandler.Blood += 1;

            //ToDo Play Animation
            if (_sound) _sound.PlayDamageSound();

            if (health <= 0) Destroy(gameObject);
        }
    }
}