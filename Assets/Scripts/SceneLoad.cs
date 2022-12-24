using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
  
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

