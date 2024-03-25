using UnityEngine;
using Script;
using Script.Player;

namespace Script.Enemy
{
public class EnemyAttak : MonoBehaviour{
    
    
    public float damageAmount = 10f; // Amount of damage to deal
    public float damageInterval = 1f; // Time interval between each damage dealing
    public float attackRange = 2f; // Range at which the damage will be dealt
    
    private float _lastDamageTime; // Time of last damage dealt
    private GameObject _player;
    private PlayerHealthHandler _playerHealthHandler;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealthHandler = PlayerHealthHandler.Instance;
    }

    private void Update()
    {
        if (Time.time - _lastDamageTime > damageInterval)
        {
            DealDamageToPlayer();
        }
    }
    
    private void DealDamageToPlayer()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        // Check if the player is within attack range
        
        if (distanceToPlayer > attackRange) return;
        
        _playerHealthHandler.DealDamage(damageAmount);
        _lastDamageTime = Time.time;
    }
}
}