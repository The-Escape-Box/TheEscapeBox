using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNum;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
        
}
