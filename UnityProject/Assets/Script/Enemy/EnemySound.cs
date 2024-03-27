using Unity.VisualScripting;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemySound : MonoBehaviour
    {
        [SerializeField] private AudioSource attackSound;
        [SerializeField] private AudioSource nearPlayerSound;
        [SerializeField] private AudioSource damageSound;

        public void PlayAttackSound()
        {
            if (!attackSound.IsUnityNull()) attackSound.Play();
        }

        public void PlayEnemyNearSound()
        {
            if (!nearPlayerSound.IsUnityNull()) nearPlayerSound.Play();
        }

        public void PlayDamageSound()
        {
            if (!damageSound.IsUnityNull()) damageSound.Play();
        }
    }
}