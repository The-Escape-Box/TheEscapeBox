using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    private void LateUpdate()
    {
        Vector3 playerViewEulerAngles = Camera.main.transform.eulerAngles;
        transform.localEulerAngles = new Vector3(0F, 0f, -playerViewEulerAngles.x + 180);
    }
}
