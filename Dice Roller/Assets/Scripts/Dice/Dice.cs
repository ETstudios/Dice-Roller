using System.Collections;
using UnityEngine;


/// <summary>
/// Handles die and physical rolling.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] private float torqueMin = 0.1f;
    [SerializeField] private float torqueMax = 2f;
    [SerializeField] private float throwStrength = 10;
    [SerializeField] private bool showAnimation = true;
    public bool IsAnimating
    {
        get { return showAnimation; }
        set { showAnimation = value; }
    }
    private Rigidbody rb;
    private int range = 0;
    private Transform startTransform;


    /// <summary>
    /// Sets properties.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startTransform = GetComponent<Transform>();
Roll(); // DEBUGGING
    }


    /// <summary>
    /// Gets random range between torque values.
    /// </summary>
    private float GetTorque()
    {
        return Random.Range(torqueMin, torqueMax);
    }



    /// <summary>
    /// Rolls the die and gets result.
    /// </summary>
    public void Roll()
    {        
        if (range == 0) { SwitchDice(6); }

        if (!showAnimation)
        {
            RollCheck();
        }
        else
        {
            // Reset die position
            rb.useGravity = false;
            transform.position = startTransform.position;
            transform.rotation = startTransform.rotation;
            rb.useGravity = true;

            // Throw die up
            rb.AddForce(Vector3.up * throwStrength, ForceMode.Impulse);

            // Rotate random amount around each axis of transform
            rb.AddTorque(transform.forward * GetTorque() + transform.up * GetTorque() + transform.right * GetTorque());
            

            StartCoroutine(WaitForStop());
        }
    }


    /// <summary>
    /// Rolls actual number.
    /// </summary>
    public int RollCheck()
    {
        int roll = -1;
        Debug.Log(roll);
        return roll;
    }


    /// <summary>
    /// Switches die mesh and collider.
    /// </summary>
    /// <param name="sides"> int Number of sides to die. </param>
    public void SwitchDice(int sides)
    {
        switch (sides)
        {
            default:
                Debug.Log("<color=red>ERROR</color> | Not a valid die number");
                break;
            case 2:
            case 4:
            case 6:
            case 8:
            case 10:
            case 12:
            case 20:
            case 100:
                // Dice mesh + collider change logic
                // Also change active number for the random range logic?
                break;
        }
    }



    /// <summary>
    /// Delays result until die stops rolling.
    /// </summary>
    private IEnumerator WaitForStop()
    {
        yield return new WaitForFixedUpdate(); // Gives chance to wait for physics to move die

        // If die is moving, wait
        while (rb.angularVelocity.sqrMagnitude > 0.1)
        {
            yield return new WaitForFixedUpdate();
        }

        RollCheck();

        StopCoroutine(WaitForStop());
    }
}

/*
 * TO DO
 *  This
 *      RollCheck()
 *          Gets result
 *          Runs RollsManager.AddResult() with roll result
 *      
 *  RollsManager
 *      Property GameObject dice
 *      Property List<int> roll results
 *      Property Camera dice camera
 *      Property RectTransform scrollrect content - used as results feed and updating scrollbar size
 *      Property Text result text (prefab) - used to instance .gameObject with each new result, set .text and .name as roll result
 *      Property Dropdown dice type - used to switch dice value
 *      Property Button roll button - used to run roll
 *              
 *      void Awake()
 *          Sets rollButton.onClick to run Roll()
 *          
 *      void AddResult(int result)
 *          Adds result to roll results list
 *          Adds instance to scrollrect content
 *          Scales scrollrect content *          
 *      
 *      void Roll()
 *              Get value of dice type dropdown, run SwitchDice() with value
 *              Run Roll()
 *              Run raycast from RollsManager.diceCamera
 *                  On hitting tag DiceSide, get first collider.name in list of colliders and use int.Parse(name) to get roll value
 */