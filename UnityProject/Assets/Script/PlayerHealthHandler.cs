using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class PlayerHealthHandler : MonoBehaviour
    {
        public float health = 100;
        public float maxHealth;
        public Image healthBar;
        public TMP_Text healthBarText;
        
        private float Health { get; set; }
        private float MaxHealth { get; set; }
        private Image HealthBar { get; set; }
        private TMP_Text HealthBarText { get; set; }
        
        public static PlayerHealthHandler Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            Instance.Health = health;
            Instance.MaxHealth = health;
            Instance.HealthBar = healthBar;
            Instance.HealthBarText = healthBarText;
        }

        // Update is called once per frame
        void Update()
        {
            HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
            HealthBarText.text = health.ToString(CultureInfo.InvariantCulture) + "/" + maxHealth.ToString(CultureInfo.InvariantCulture);
        }

        public void Heal(int healAmount)
        {
            Health = Math.Min(100, Health + 50);
        }
    }
}
