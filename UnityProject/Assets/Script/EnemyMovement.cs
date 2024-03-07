using System.Collections;
using Script;
using UnityEngine;
using UnityEngine.AI;

public class DemonMovement : MonoBehaviour
{
    public Transform player; // Public variable to assign the player in the editor
    private NavMeshAgent agent;
    private Animator anim;
    private float _health = 5F;
    
    private BloodBankHandler _bloodBankHandler;

    int hIdles;
    int hAngry;
    int hAttack;
    int hGrabs;

    public float attackDistance = 5f; // Distance at which the demon attacks
    public float grabDistance = 2f;   // Distance at which the demon grabs the player

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Set up hash IDs for animation states
        hIdles = Animator.StringToHash("Idles");
        hAngry = Animator.StringToHash("Angry");
        hAttack = Animator.StringToHash("Attack");
        hGrabs = Animator.StringToHash("Grabs");
        
        // Set up global handler
        _bloodBankHandler = BloodBankHandler.Instance;
    }

    void Update()
    {
        // Set the destination of the NavMeshAgent to the player's position
        agent.destination = player.position;

        // Check distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Determine which animation to play based on distance
        if (distanceToPlayer <= attackDistance)
        {
            // Player is close enough to attack
            Attack();
        }
        else if (distanceToPlayer <= grabDistance)
        {
            // Player is too close, use Grabs animation
            Grabs();
        }
        else
        {
            // Player is far, return to idle state
            UpdateAnimation(false);
        }
    }

    void UpdateAnimation(bool isMoving)
    {
        // Set animation parameters based on movement
        anim.SetBool(hIdles, !isMoving);
        anim.SetBool(hAngry, false); // Assuming Angry animation is not movement-based
        anim.SetBool(hAttack, false); // Assuming Attack animation is not movement-based
        anim.SetBool(hGrabs, false); // Assuming Grabs animation is not movement-based
    }

    void Attack()
    {
        // Trigger attack animation
        UpdateAnimation(false); // Stop any movement animation
        anim.SetBool(hAttack, true);
    }

    void Grabs()
    {
        // Trigger grabs animation
        UpdateAnimation(false); // Stop any movement animation
        anim.SetBool(hGrabs, true);
    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        _bloodBankHandler.Blood += 1;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

