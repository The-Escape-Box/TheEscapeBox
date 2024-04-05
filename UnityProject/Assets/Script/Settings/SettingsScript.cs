using Script.Player;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

namespace Script.Settings
{
    public class SettingsScript : MonoBehaviour
    {
        public Slider sensitivitySlider;
        public PlayerCamera mouseSensitivityControl;
        
        private GameObject _settings;

        private void Awake()
        {
            _settings = transform.GetChild(0).gameObject;
            _settings.SetActive(false);
        }
        
        void Start()
        {
            sensitivitySlider.value = mouseSensitivityControl.mouseSensitivity;
            sensitivitySlider.onValueChanged.AddListener(HandleSensitivityChange);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) ToggleSettings();
        }
        
        void HandleSensitivityChange(float sensitivity)
        {
            mouseSensitivityControl.mouseSensitivity = sensitivity;
        }

        public void ToggleSettings()
        {
            var active = !_settings.activeSelf;
            _settings.SetActive(active);
            if (active)
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