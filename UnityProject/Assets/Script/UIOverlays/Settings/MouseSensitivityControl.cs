using Script.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UIOverlays.Settings
{
    public class MouseSensitivityControl : MonoBehaviour
    {
        private PlayerCamera _mouseSensitivityControl;
        private Slider _sensitivitySlider;
        private GameObject _settings;
        
        void Start()
        {
            _mouseSensitivityControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
            _sensitivitySlider = GetComponent<Slider>();

            _sensitivitySlider.value = _mouseSensitivityControl.mouseSensitivity;
            _sensitivitySlider.onValueChanged.AddListener(HandleSensitivityChange);
        }
        
        void HandleSensitivityChange(float sensitivity)
        {
            _mouseSensitivityControl.mouseSensitivity = sensitivity;
        }
    }
}