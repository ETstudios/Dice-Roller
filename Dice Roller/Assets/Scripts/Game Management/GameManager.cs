using UnityEngine;

/// <summary>
/// Handles global information for game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private string firstScreen;

    private ScenesManager sceneManager;
    public ScenesManager Scenes
    {
        get { return sceneManager; }
        set { sceneManager = value; }
    }


    /// <summary>
    /// Creates singleton and sets properties.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
        sceneManager = GetComponent<ScenesManager>();
        sceneManager.SceneSwitch(firstScreen);
    }
}
