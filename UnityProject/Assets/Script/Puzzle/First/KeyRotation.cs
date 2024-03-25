using UnityEngine;

namespace Script.Puzzle.First
{
    public class KeyRotation : MonoBehaviour
    {
        public float rotationSpeed = 50f;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}

