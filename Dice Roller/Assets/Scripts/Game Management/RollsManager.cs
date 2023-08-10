using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles dice roll UI.
/// </summary>
public class RollsManager : MonoBehaviour
{
    [SerializeField] private GameObject dice;
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
}
/*              
 *      void Awake()
 *          Sets rollButton.onClick to run Roll()
 *          Sets clearButton.onClick to run Clear()
 *          
 *      void AddResult(int result)
 *          Adds result to roll results list
 *          Adds instance to scrollrect content
 *              Instance .gameObject with each new result
 *              Set .text and .name as roll result
 *          Scales scrollrect content * instance height
 *          
 *      void Clear()
 *          Reloads scene
 *      
 *      void Roll()
 *              Get value of dice type dropdown, run SwitchDice() with value
 *              Run Roll()
 *              Run raycast from RollsManager.diceCamera
 *                  On hitting tag DiceSide, get first collider.name in list of colliders and use int.Parse(name) to get roll value
 *                  
 *                  
 *      Convert resultsList to Dictionary, using roll number as index, for sorting?
 */