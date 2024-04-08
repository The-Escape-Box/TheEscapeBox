using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI.Overlays
{
    public class OverlayHandler : MonoBehaviour
    {
        [SerializeField]private GameObject settingsOverlay;
        [SerializeField]private GameObject shopOverlay;

        public bool SettingsOpen { get; set; }
        public bool ShopOpen { get; set; }
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ShopOpen)
                {
                    ShopOpen = false;
                    
                    CheckGamePause();
                    return;
                }

                SettingsOpen = !settingsOverlay.activeSelf;
                CheckGamePause();
                return;
            }           
            
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (SettingsOpen)
                {
                    return;
                }
                ShopOpen = !shopOverlay.activeSelf;
                CheckGamePause();
            }
        }

        private void CheckGamePause()
        {
            shopOverlay.SetActive(ShopOpen);
            settingsOverlay.SetActive(SettingsOpen);
            
            if (ShopOpen || SettingsOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                return;
            }   
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
