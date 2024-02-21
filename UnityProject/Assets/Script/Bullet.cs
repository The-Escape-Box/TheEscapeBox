using UnityEngine;

namespace Script
{
    public class Bullet: MonoBehaviour
    {
    public float maxFlyTime = 5;
    
    public bool ReadyToFly { get; set; }

    private void Update()
    {
        if (maxFlyTime < 0)
        {
            Destroy(gameObject);
        }
        if (!ReadyToFly) return;
        
        transform.Translate(Vector3.forward);
        maxFlyTime -= Time.deltaTime;
    }
    }
    
}