using TMPro;
using UnityEngine;

namespace Script
{
    public class AmmunitionHandler : MonoBehaviour
    {
        public int initialAmmunition = 5;
        public float initialAmmunitionStunTime = 3F;
        public float initialBulletDamage = 1F;
        public float initialBulletSpeed = 100F; // Add this line

        public TMP_Text ammunitionText;

        public int Ammunition { get; set; }
        public float AmmunitionStunTime { get; set; }
        public float BulletDamage { get; set; }
        public float BulletSpeed { get; set; } // Add this line

        public static AmmunitionHandler Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            Instance.Ammunition = initialAmmunition;
            Instance.AmmunitionStunTime = initialAmmunitionStunTime;
            Instance.BulletDamage = initialBulletDamage;
            Instance.BulletSpeed = initialBulletSpeed; // Add this line
        }

        private void Update()
        {
            ammunitionText.text = Ammunition.ToString();
        }
    }
}
