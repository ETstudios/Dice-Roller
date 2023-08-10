using UnityEngine;

/// <summary>
/// Pointer script for dice mesh options.
/// </summary>
public class DieOption : MonoBehaviour
{
    [SerializeField] private int diceSides;
    public string Sides
    {
        get { return diceSides.ToString(); }
        set { diceSides = int.Parse(value); }
    }
}
