using UnityEngine;

namespace Script
{
    public class UpgradeService : MonoBehaviour
    {
        private BloodBankHandler _bloodBankHandler;
        private AmmunitionHandler _ammunitionHandler;
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
            if (blood > bloodCost)
            { 
                _playerHealthHandler.Heal(50);
            }
        }

        public void BuyAmmunition(int bloodCost)
        {
            var blood = _bloodBankHandler.Blood;
            if (blood > bloodCost)
            {
                _ammunitionHandler.Ammunition++;
            }        
        }
    }
}
