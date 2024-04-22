using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class SecondPuzzle : MonoBehaviour
{
    // Public variable to assign the player object in the Unity Editor
    public Transform player;
    private StatTracker _statTracker;

    private void Start()
    {
        _statTracker = StatTracker.Instance;
    }

    void Update()
    {
        // Ensure the player has been assigned
        if (player != null)
        {
            // Calculate the distance between the current object's position and the player's position
            float distance = Vector3.Distance(transform.position, player.position);
            print(distance);
            
            if(distance <=5)
            {
                print("now load the scene");
                _statTracker.OnSceneChangeTo(5);
                SceneManager. LoadScene(5);
            }
          
        }
       
    }
}
