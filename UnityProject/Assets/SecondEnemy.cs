using UnityEngine;
using UnityEngine.AI; // Import the AI namespace for NavMeshAgent

public class SecondEnemy : MonoBehaviour
{
    public Transform playerTransform; // Public variable to assign the player's transform in the editor
    private NavMeshAgent navAgent; // Variable to hold the NavMeshAgent component

    // Static variable to keep count of collisions
    public static int collisionCount = 0;

    void Start()
    {
        // Get the NavMeshAgent component attached to this enemy
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the playerTransform has been assigned
        if(playerTransform != null)
        {
            // Uncomment the following line to enable chasing the player
            // navAgent.SetDestination(playerTransform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Print the tag of the object it collided with
        Debug.Log("Collided with tag: " + collision.gameObject.tag);

        // Check if the object we collided with has the tag "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Increment the collision count
            collisionCount++;

            // Optionally, destroy the bullet after hitting the enemy
            // Destroy(collision.gameObject); // Uncomment if you want to destroy the bullet upon collision

            // Print the collision count when it reaches 50
            if(collisionCount == 50)
            {
                Debug.Log("Bullet has collided with enemies " + collisionCount + " times.");
                // Destroy this enemy object after 50 collisions with bullets
                Destroy(gameObject);
            }
        }
    }
}
