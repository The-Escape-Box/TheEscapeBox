using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Puzzle.First
{
    public class PuzzleManager : MonoBehaviour
    {
        public Light[] spotlights;
        public PuzzleHint puzzleHint; // Reference to the PuzzleHint script
        public bool hasTheKey = false; // Variable to track if the key has been obtained
        public List<GameObject> enemyPrefabs; // List of enemy prefabs
        public List<Vector3> enemySpawnPositions; // List of enemy spawn positions
        public float activationInterval = 10f; // Time interval between enemy activations

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                if (hasTheKey)
                {
                    // Change the color of spotlights to FFD580
                    foreach (Light spotlight in spotlights)
                    {
                        spotlight.color = new Color(1f, 0.839f, 0.502f); // FFD580 in RGB
                    }
                    string hintText = "Shit! you just turn the light on, you need to escape the box";
                    puzzleHint.SetText(hintText); // Pass the printed text to the PuzzleHint script

                    // Start activating enemies at intervals
                    StartCoroutine(ActivateEnemiesRoutine());
                }
                else
                {
                    string hintText = "A key is a solution!";
                    puzzleHint.SetText(hintText); // Pass the printed text to the PuzzleHint script
                }
            }
        }

        IEnumerator ActivateEnemiesRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(activationInterval);

                int spawnPositionCount = enemySpawnPositions.Count;
                if (spawnPositionCount > 0 && enemyPrefabs.Count > 0)
                {
                    int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
                    int randomPositionIndex = Random.Range(0, spawnPositionCount);
                    Vector3 spawnPosition = enemySpawnPositions[randomPositionIndex];

                    GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];
                    GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyInstance.SetActive(true);
                }
            }
        }
    }
}
