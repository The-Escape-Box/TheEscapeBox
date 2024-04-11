using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Puzzle.First
{
    public class PuzzleManager : MonoBehaviour
    {
        public Light[] spotlights;
        public PuzzleHint puzzleHint; // Reference to the PuzzleHint script
        public bool hasTheKey; // Variable to track if the key has been obtained
        public List<GameObject> enemyPrefabs; // List of enemy prefabs
        public List<Vector3> enemySpawnPositions; // List of enemy spawn positions
        public float activationInterval = 15f; // Time interval between enemy activations

        public GameObject portal;

        private void Start()
        {
            StartCoroutine(ActivateEnemiesRoutine());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (hasTheKey)
            {
                // Change the color of spotlights to FFD580
                foreach (var spotlight in
                         spotlights) spotlight.color = new Color(1f, 0.839f, 0.502f); // FFD580 in RGB
                var hintText = "Shit! you just turn the light on, you need to escape the box";
                puzzleHint.SetText(hintText); // Pass the printed text to the PuzzleHint script

                // Start let spawn more enemys
                activationInterval = 10F;
                if (!portal.IsUnityNull())
                {
                    portal.SetActive(true);
                }
            }
            else
            {
                var hintText = "A key is a solution!";
                puzzleHint.SetText(hintText); // Pass the printed text to the PuzzleHint script
            }
        }

        private IEnumerator ActivateEnemiesRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(activationInterval);

                var spawnPositionCount = enemySpawnPositions.Count;
                if (spawnPositionCount > 0 && enemyPrefabs.Count > 0)
                {
                    var randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
                    var randomPositionIndex = Random.Range(0, spawnPositionCount);
                    var spawnPosition = enemySpawnPositions[randomPositionIndex];

                    var enemyPrefab = enemyPrefabs[randomEnemyIndex];
                    var enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyInstance.SetActive(true);
                }
            }
        }
    }
}