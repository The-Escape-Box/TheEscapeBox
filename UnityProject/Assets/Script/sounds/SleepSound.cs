using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepSound : MonoBehaviour
{
   
    public float triggerDistance = 5.0f; // Distance at which the sound will play
    public AudioSource audioSource; // Reference to the AudioSource component

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the cinema object
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position); // Calculate the distance
            if (distance <= triggerDistance && !audioSource.isPlaying)
            {
                audioSource.Play(); // Play the sound if too close and not already playing
            }
            else if (distance > triggerDistance && audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop the sound if the player is far enough away
            }
        }
    }
}
