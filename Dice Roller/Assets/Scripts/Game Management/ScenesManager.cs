using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles scene switching logic.
/// </summary>
public class ScenesManager : MonoBehaviour
{
    private string currentScene;
    public string Current
    {
        get { return currentScene; }
        set { currentScene = value; }
    }


    public void SceneSwitch(string targetScene)
    {
        currentScene = targetScene;
        SceneManager.LoadScene(targetScene);
    }
}
