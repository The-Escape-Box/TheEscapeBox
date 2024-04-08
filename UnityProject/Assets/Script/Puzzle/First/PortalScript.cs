using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Puzzle.First
{
    public class PortalScript : MonoBehaviour
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            { 
                SceneManager.LoadScene("SecondMap");
            }
            
        }
    }
}
