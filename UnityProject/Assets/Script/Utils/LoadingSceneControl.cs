using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // Include if using a UI element to show progress

namespace Script.Utils
{
    public class LoadingScreenControl : MonoBehaviour
    {
        [SerializeField] private int sceneToLoad;

        private StatTracker _statTracker;

        private void Start()
        {
            _statTracker = StatTracker.Instance;
            var videoPlayer = GetComponent<VideoPlayer>();
            if(videoPlayer != null)
            {
                videoPlayer.Play(); // Start video playback if not set to play on awake
                
                videoPlayer.loopPointReached += OnVideoEnd;
            }
        
            StartCoroutine(LoadSceneAsync(sceneToLoad));
        }

        IEnumerator LoadSceneAsync(int scene)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
            asyncLoad.allowSceneActivation = false; // Prevent the scene from being activated as soon as it's loaded

            // Wait until the video has finished playing
            while (!asyncLoad.isDone)
            {
                // Check if the loading is complete
                if (asyncLoad.progress >= 0.9f)
                {
                    // Wait for the video to finish
                    break;
                }
                yield return null;
            }
        }
        
        void OnVideoEnd(VideoPlayer vp)
        {
            // The video has finished playing, activate the loaded scene
            _statTracker.OnSceneChangeTo(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);

        }
    }

}