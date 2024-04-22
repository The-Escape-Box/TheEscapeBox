using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Puzzle.First
{
    public class PortalScript : MonoBehaviour
    {
        private StatTracker _statTracker;

        private void Start()
        {
            _statTracker = StatTracker.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            { 
                _statTracker.OnSceneChangeTo(3);
                SceneManager.LoadScene("FirstToSecond");
            }
        }
    }
}
