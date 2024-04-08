using System;
using UnityEngine;

namespace Script.UI.Overlays
{
    public class OverlayHandler : MonoBehaviour
    {
        private GameObject _settingsOverlay;
        private GameObject _shopOverlay;

        private bool _settingsOpen;
        private bool _shopOpen;

        private void Start()
        {
            _settingsOverlay = GameObject.FindWithTag("PauseMenu");
            _shopOverlay = GameObject.FindWithTag("Shop");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_shopOpen)
                {
                    _shopOverlay.SetActive(false);
                    _shopOpen = false;
                    
                    CheckGamePause();
                    return;
                }

                _settingsOpen = !_settingsOverlay.activeSelf;
                _settingsOverlay.SetActive(!_settingsOpen);
                
                CheckGamePause();
                return;
            }           
            
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_settingsOpen)
                {
                    return;
                }
                _shopOpen = !_shopOverlay.activeSelf;
                _shopOverlay.SetActive(_shopOverlay);
                
                CheckGamePause();
            }
        }

        private void CheckGamePause()
        {
            var isPause = _shopOpen || _settingsOpen;
            if (isPause)
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
