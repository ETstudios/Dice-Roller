using System.Collections;
using System.Collections.Generic;
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

    private RollsManager manager;
    private Rigidbody rb;
    private int range = 0;
    private Transform startTransform;
    private Dictionary<string, GameObject> diceOptions = new Dictionary<string, GameObject>();


    /// <summary>
    /// Sets properties.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startTransform = GetComponent<Transform>();
        manager = FindObjectOfType<RollsManager>(true);
Roll(); // DEBUGGING
    }


    private void Start()
    {
        foreach (DieOption die in GetComponentsInChildren<DieOption>(true))
        {
            diceOptions.Add(die.Sides, die.gameObject);
        }
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
        // Run RollsManager.ResetCam()
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
        return roll;
    }


    /// <summary>
    /// Switches die mesh and collider.
    /// </summary>
    /// <param name="sides"> int Number of sides to die. </param>
    public void SwitchDice(int sides)
    {
        bool isValidDie = false;

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
                isValidDie = true;
                break;
        }

        if (isValidDie && diceOptions.Count > 0)
        {
            foreach (string index in diceOptions.Keys)
            {
                string side = sides.ToString();
                if (side == index)
                {
                    diceOptions[side].SetActive(true);
                }
                else
                {
                    diceOptions[side].SetActive(false);
                }
            }
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
 *          Gets result using RollsManager.DiceCam as raycaster
 *              Have RollsManager.diceCamera look toward die
 *              Run raycast from RollsManager.diceCamera
 *              On hitting tag DiceSide, get first collider.name in list of colliders and use int.Parse(name) to get roll value
 *          Runs RollsManager.AddResult() with roll result
 *          
 *      SwitchDice()
 *          Switch model to use, nested inside this object
 */