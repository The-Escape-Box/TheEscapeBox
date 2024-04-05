using Script.Player;
using UnityEngine;

namespace Script.Shop
{
    public class UpgradeService : MonoBehaviour
    {
        private AmmunitionHandler _ammunitionHandler;
        private BloodBankHandler _bloodBankHandler;
        private PlayerHealthHandler _playerHealthHandler;

        private void Start()
        {
            _bloodBankHandler = BloodBankHandler.Instance;
            _ammunitionHandler = AmmunitionHandler.Instance;
            _playerHealthHandler = PlayerHealthHandler.Instance;
        }

        public void Heal(int bloodCost)
        {
            var blood = _bloodBankHandler.Blood;
            if (blood <= bloodCost) return;

            _playerHealthHandler.Heal(50);
            _bloodBankHandler.Blood -= bloodCost;
        }

        public void BuyAmmunition(int bloodCost)
        {
            var blood = _bloodBankHandler.Blood;
            if (blood <= bloodCost) return;

            _ammunitionHandler.Ammunition += 256;
            _bloodBankHandler.Blood -= bloodCost;
        }

        public void UpgradeDamage(int bloodCost)
        {
            var blood = _bloodBankHandler.Blood;
            if (blood <= bloodCost) return;

            _ammunitionHandler.BulletDamage++;
            _bloodBankHandler.Blood -= bloodCost;
        }
    }
}