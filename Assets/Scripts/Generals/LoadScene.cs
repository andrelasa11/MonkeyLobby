using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //public string sceneToLoad;

    public void DoLoadScene(string scene)
    {
        Debug.Log("Loading...");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
}
