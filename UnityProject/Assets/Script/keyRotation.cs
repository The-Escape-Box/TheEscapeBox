using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust this to change the rotation speed

    // Update is called once per frame
    void Update()
    {
        // Rotate the key around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

