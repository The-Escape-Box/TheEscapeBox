using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the enemy prefab in the inspector
    private float spawnInterval = 5F; // Time between each spawn
    private float spawnRadius = 10F; // Radius within which enemies can spawn

    private bool spawning = true; // Control whether enemies should currently be spawning

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        // Sample a valid point on the NavMesh within the spawnRadius
        if (NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, NavMesh.AllAreas))
        {
            finalPosition = hit.position;
            Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("Failed to find a valid point on the NavMesh!");
        }
    }

    public void StopSpawning()
    {
        spawning = false; // Call this method to stop spawning enemies
    }
}