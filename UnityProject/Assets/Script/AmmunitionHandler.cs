using UnityEngine;

namespace Script
{
    public class AmmunitionHandler : MonoBehaviour
    {
        public int initialAmmunition = 5;
        public int Ammunition { get; set; }

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
        }
    }
}