using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ChestScript : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            SceneManager.LoadScene(2);
        }
    }
}
