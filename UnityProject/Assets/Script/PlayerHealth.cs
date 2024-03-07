using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class PlayerHealth : MonoBehaviour
    {
        public float health = 100;
        public float maxHealth;
        public Image healthBar;
        public TMP_Text healthBarText;
    
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = health;
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
            healthBarText.text = health.ToString(CultureInfo.InvariantCulture) + "/" + maxHealth.ToString(CultureInfo.InvariantCulture);
        }
    }
}
