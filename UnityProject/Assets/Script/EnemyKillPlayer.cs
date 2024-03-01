using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyKillPlayer : MonoBehaviour
{
    public float detectionRange = 3f; // Adjust as needed
    public float sceneChangeDelay = 1f; // Time delay before changing the scene
    public GameObject player;
    private bool playerKilled = false;

    private void Update()
    {
        // Check the distance between enemy and player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If player is within detection range, kill player
        if (distance <= detectionRange && !playerKilled)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        player.SetActive(false);
        playerKilled = true;
        StartCoroutine(ChangeSceneAfterDelay(sceneChangeDelay)); // Change scene after the specified delay
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3); 
    }
}
