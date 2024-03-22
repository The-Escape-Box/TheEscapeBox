using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private bool hasTheKey = false;
    public PuzzleManager puzzleManager; // Reference to the PuzzleManager script

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            // Find the GameObject with the "Key" tag and destroy it
            GameObject keyObject = GameObject.FindGameObjectWithTag("Key");
            if (keyObject != null)
            {
                Destroy(keyObject);
                hasTheKey = true;
                // Pass the hasTheKey value to PuzzleManager
                puzzleManager.hasTheKey = hasTheKey;
            }
        }
    }
}
