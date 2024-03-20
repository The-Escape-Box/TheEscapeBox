using System;
using UnityEngine;

namespace Script
{
    public class ShopScript : MonoBehaviour
    {
        private GameObject _shop;

        private void Awake()
        {
            _shop = transform.GetChild(0).gameObject;
            _shop.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                setInventoryActive(true);
            }
        }

        public void setInventoryActive(bool active)
        {
            _shop.SetActive(active);
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
