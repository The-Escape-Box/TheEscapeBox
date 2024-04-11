using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Puzzle.First
{
    public class Key : MonoBehaviour
    {
        public PuzzleManager puzzleManager; // Reference to the PuzzleManager script
        public GameObject guiKey;
        
        private bool _hasTheKey;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _hasTheKey = true;
            if (!guiKey.IsUnityNull())
            {
                guiKey.SetActive(_hasTheKey);
            }
            puzzleManager.hasTheKey = _hasTheKey;
            Destroy(gameObject);
        }
    }
}