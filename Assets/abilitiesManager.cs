using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilitiesManager : MonoBehaviour {
	public string primaryAbility;
	public string secondaryAbility;

	Text primaryText;
	Text secondaryText;

	// Use this for initialization
	void Start () {
		primaryText = GameObject.Find ("primary ability").GetComponent<Text> ();
		secondaryText = GameObject.Find ("secondary ability").GetComponent<Text> ();

		primaryText.text = "";
		secondaryText.text = "";

		if (primaryAbility != null) {
			primaryText.text = primaryAbility;
		}
		if (secondaryAbility != null) {
			secondaryText.text = secondaryAbility;
		}
	}
}