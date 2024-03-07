using UnityEngine;

namespace Script
{
    public class BloodBankHandler : MonoBehaviour
    {
        public int initialBlood = 5;
        
        public int Blood { get; set; }

        public static BloodBankHandler Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            Instance.Blood = initialBlood;
        }
    }
}
