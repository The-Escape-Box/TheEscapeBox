using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public int sceneNum;

        private StatTracker _statTracker;

        private void Start()
        {
            _statTracker = StatTracker.Instance;
        }

        public void LoadScene()
        {
            _statTracker.OnSceneChangeTo(sceneNum);
            SceneManager.LoadScene(sceneNum);
        }
    }
}