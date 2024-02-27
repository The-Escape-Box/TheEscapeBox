using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int SceneNum;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
