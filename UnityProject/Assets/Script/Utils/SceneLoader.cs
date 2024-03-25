using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public int sceneNum;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}