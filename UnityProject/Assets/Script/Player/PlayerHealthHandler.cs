using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Player
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
            Instance.MaxHealth = maxHealth;
            Instance.HealthBar = healthBar;
            Instance.HealthBarText = healthBarText;
        }

        // Update is called once per frame
        private void Update()
        {
            HealthBar.fillAmount = Mathf.Clamp(Health / MaxHealth, 0, 1);
            HealthBarText.text = Health.ToString(CultureInfo.InvariantCulture) + "/" +
                                 MaxHealth.ToString(CultureInfo.InvariantCulture);
        }

        public void Heal(int healAmount)
        {
            Health = Math.Min(100, Health + healAmount);
        }

        public void DealDamage(float damage)
        {
            Health -= damage;
            if (Health > 0) return;

            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
}