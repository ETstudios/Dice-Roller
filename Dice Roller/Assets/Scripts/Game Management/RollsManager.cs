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
    [SerializeField] private Text resultTemplate;
    [SerializeField] private Dropdown diceType;
    [SerializeField] private Button rollButton;
    [SerializeField] private Button clearButton;

    private List<int> resultsList = new List<int>();
    private Transform diceCameraOrigin;


    /// <summary>
    /// Set properties and button actions.
    /// </summary>
    private void Awake()
    {
        rollButton.onClick.AddListener( delegate { Roll(); });
        clearButton.onClick.AddListener( delegate { Clear(); });
        diceCameraOrigin = diceCamera.transform;
        if (dice == null) { dice = FindObjectOfType<Dice>(true); }
    }


    /// <summary>
    /// Adds result to list and UI.
    /// </summary>
    /// <param name="result"> int Result of roll. </param>
    public void AddResult(int result)
    {

    }


    /// <summary>
    /// Resets scene to clear rolls list.
    /// </summary>
    private void Clear()
    {
        // Run SceneManager.LoadScene(SceneManager.GetScene())
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
        dice.Roll();
    }
}
/*          
 *      void AddResult(int result)
 *          Adds result to roll results list
 *          Adds instance to scrollrect content
 *              Instance .gameObject with each new result
 *              Set .text and .name as roll result
 *          Scales scrollrect content * instance height
 *      
 *      void Roll()
 *              Get value of dice type dropdown, run SwitchDice() with value
 *              Run Roll()
 *              
 *              
 *                  
 *      Convert resultsList to Dictionary, using roll number as index, for sorting?
 */