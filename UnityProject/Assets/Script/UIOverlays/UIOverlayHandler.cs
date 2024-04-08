using System;
using UnityEngine;

public class UIOverlayHandler : MonoBehaviour
{
    private GameObject _settingsOverlay;
    private GameObject _shopOverlay;

    private void Awake()
    {
        _settingsOverlay = GameObject.FindGameObjectWithTag("PauseMenu");
        _shopOverlay = GameObject.FindGameObjectWithTag("Shop");
    }
}
