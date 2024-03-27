using UnityEngine;

namespace Script.Puzzle.First
{
    public class Key : MonoBehaviour
    {
        public PuzzleManager puzzleManager; // Reference to the PuzzleManager script

        private bool _hasTheKey;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Key")) return;

            var keyObject = GameObject.FindGameObjectWithTag("Key");
            if (keyObject == null) return;
            Destroy(keyObject);
            _hasTheKey = true;

            puzzleManager.hasTheKey = _hasTheKey;
        }
    }
}