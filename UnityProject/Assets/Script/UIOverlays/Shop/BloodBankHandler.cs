using TMPro;
using UnityEngine;

namespace Script.UIOverlays.Shop
{
    public class BloodBankHandler : MonoBehaviour
    {
        public int initialBlood = 5;
        public TMP_Text bloodText;

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

        private void Update()
        {
            bloodText.text = Blood.ToString();
        }
    }
}