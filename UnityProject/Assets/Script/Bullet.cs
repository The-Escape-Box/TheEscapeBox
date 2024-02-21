using UnityEngine;

namespace Script
{
    public class Bullet: MonoBehaviour
    {
    public float bulletSpeed = 5;
    public float maxFlyTime = 5;
    
    public Vector3 TargetDirection { get; set; }
    public bool ReadyToFly { get; set; }

    private void Update()
    {
        if (maxFlyTime < 0)
        {
            Destroy(gameObject);
        }
        if (!ReadyToFly) return;
        
        var movement = TargetDirection * bulletSpeed * Time.deltaTime; 
        transform.Translate(movement);
        maxFlyTime -= Time.deltaTime;
    }
    }
    
}