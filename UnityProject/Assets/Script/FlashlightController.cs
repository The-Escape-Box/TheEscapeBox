using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private float defaultXRotationOffset = 90f; // Adjust this value to set the default rotation offset

    private void LateUpdate()
    {
        // Get the current rotation of the camera
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // Calculate the target rotation for the flashlight based on the camera's rotation
        float targetXRotation = cameraRotation.eulerAngles.x + defaultXRotationOffset;

        // Apply the new rotation to the flashlight
        transform.localRotation = Quaternion.Euler(targetXRotation, 0f, 0f);
    }
}
