using UnityEngine;

namespace Script.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;

        private float xRotation;

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f); // Clamp the rotation here

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        private void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}