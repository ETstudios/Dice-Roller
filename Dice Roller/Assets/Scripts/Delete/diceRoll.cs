using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diceRoll : MonoBehaviour {
	private int rolled; // Result of the current rolled die
	private string dice = ""; // List of rolled dice
	public Text diceRolls; // Textbox for the list
	public Scrollbar scroll; // Textbox's scrollbar
	private RectTransform rollsRect; // Container for the textbox
	private int count; // Keeps track of number of dice rolled
	public int diceRollsLimit = 22; // Number of entries that will spawn before scrolling starts

	void Start() {
		rolled = 0;
		count = 0;
		diceRolls.text = "";
		rollsRect = diceRolls.GetComponent<RectTransform>();
	}

	public void roll(int dieNum) { // Rolls a die between 1 and the associated die's maximum and adds to the list
		rolled = Mathf.RoundToInt(Random.Range(1, dieNum+1));
		dice += rolled + "\n";
		diceList();
	}

	public void clearRolls() { // Resets rolls list
		dice = "";
		if(count > diceRollsLimit) {
			rollsRect.sizeDelta = new Vector2(1.6f, -86.7f);
			rollsRect.localPosition = new Vector3(-22.1f, 0, 0);
			count = 0;
		} else {
			count = 0;
		}
		diceList();
	}

	private void diceList() {
		diceRolls.text = dice;
		count = count+1;
		if(count > diceRollsLimit) { // Scales the textbox's container and keeps scroll updated as list grows past the roll limit
			rollsRect.sizeDelta += new Vector2(0, 42f);
			rollsRect.localPosition += new Vector3(0, 1f, 0);
			scroll.value = 0;
		}
	}
}