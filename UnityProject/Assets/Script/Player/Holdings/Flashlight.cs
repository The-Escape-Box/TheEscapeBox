using UnityEngine;

namespace Script.Player.Holdings
{
    public class Flashlight : MonoBehaviour
    {
        public GameObject hand;

        private void LateUpdate()
        {
            var playerViewEulerAngles = Camera.main.transform.eulerAngles;

            hand.transform.localEulerAngles = new Vector3(-90F, -playerViewEulerAngles.x, 0);
        }
    }
}