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


    /// <summary>
    /// Gets Vector2 for scaling scrollrect content.
    /// </summary>
    /// <param name="contentBox"> rectTransform The content box within scrollrect to scale. </param>
    /// <param name="multiplier"> int How many times to scale contentBox. </param>
    /// <param name="scaler"> float Size by which to scale. </param>
    /// <returns></returns>
    public Vector2 ContentScale(RectTransform contentBox, int multiplier, float scaler)
    {
        float scaleX = contentBox.sizeDelta.x;
        float scaleY = contentBox.sizeDelta.y;
        float adjustedSize = scaleY + (multiplier * scaler);
        Vector2 newScale = new Vector2(scaleX, adjustedSize);
        return newScale;
    }
}
