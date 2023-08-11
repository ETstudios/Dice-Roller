using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles dice roll UI.
/// </summary>
public class RollsManager : MonoBehaviour
{
    [SerializeField] private Dice dice;
    [SerializeField] private Camera diceCamera;
    public Camera DiceCam
    {
        get { return diceCamera; }
        set { diceCamera = value; }
    }


    [Space, Header("UI")]
    [SerializeField] private RectTransform scrollrectContent;
    [SerializeField] private RectTransform resultsFeed;
    [SerializeField] private Text resultTemplate;
    [SerializeField] private Dropdown diceType;
    [SerializeField] private Button rollButton;
    [SerializeField] private Button clearButton;

    private GameManager manager;
    private List<int> resultsList = new List<int>();
    private Transform diceCameraOrigin;
    private float resultHeight;


    /// <summary>
    /// Set properties and button actions.
    /// </summary>
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>(true);
        rollButton.onClick.AddListener( delegate { Roll(); });
        clearButton.onClick.AddListener( delegate { Clear(); });
        diceCameraOrigin = diceCamera.transform;
        if (dice == null) { dice = FindObjectOfType<Dice>(true); }
        resultHeight = resultTemplate.GetComponent<RectTransform>().sizeDelta.y;
    }


    /// <summary>
    /// Adds result to list and UI.
    /// </summary>
    /// <param name="result"> int Result of roll. </param>
    public void AddResult(int result)
    {
        resultsList.Add(result);

        if (scrollrectContent != null && resultsFeed != null && resultTemplate != null)
        {
            GameObject instance = Instantiate(resultTemplate.gameObject, resultsFeed, false);
            string roll = result.ToString();
            instance.name = roll;
            instance.GetComponent<Text>().text = $"{roll}";
            instance.SetActive(true);
            scrollrectContent.sizeDelta = manager.ContentScale(scrollrectContent, 1, resultHeight);
        }
        rollButton.interactable = true;
    }


    /// <summary>
    /// Resets scene to clear rolls list.
    /// </summary>
    private void Clear()
    {
        manager.Scenes.SceneSwitch(manager.Scenes.Current);
    }


    /// <summary>
    /// Points camera at die.
    /// </summary>
    public void FocusCam()
    {
        FocusCam(dice.transform);
    }

    public void FocusCam(Transform target)
    {
        // diceCamera.transform.LookAt(target);
    }


    /// <summary>
    /// Resets dice camera transform.
    /// </summary>
    public void ResetCam()
    {
        diceCamera.transform.rotation = diceCameraOrigin.rotation;
    }


    /// <summary>
    /// Runs dice roll.
    /// </summary>
    public void Roll()
    {
        if (rollButton.interactable)
        {
            rollButton.interactable = false;
            dice.Roll();
        }        
    }
}
/*
 *      void Roll()
 *              Get value of dice type dropdown, run SwitchDice() with value
 *                  
 *      Convert resultsList to Dictionary, using roll number as index, for sorting?
 */