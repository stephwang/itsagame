using System;
using UnityEngine;
using UnityEngine.UI;

public class abilityMenu : MonoBehaviour {
	public GameObject abilityButtonPrefab;
	public GameObject modifierButtonPrefab;

	// Use this for initialization
	void Awake () {
		PopulateAbilityMenuPanes ();
	}
		
	void PopulateAbilityMenuPanes() {
		// Populate abilities
		GameObject abilityPane = GameObject.Find ("Abilities Pane");
		foreach(Constants.Ability ability in Enum.GetValues (typeof(Constants.Ability))) {
			string abilityString = ability.ToString ();
			GameObject abilityButton = Instantiate (abilityButtonPrefab, abilityPane.transform);
			abilityButton.name = abilityString;
			abilityButton.GetComponentInChildren<Text>().text = abilityString;
		}

		// Populate modifiers
		GameObject modifierPane = GameObject.Find ("Modifiers Pane");
		foreach(Constants.Modifier modifier in Enum.GetValues (typeof(Constants.Modifier))) {
			string modifierString = modifier.ToString ();
			GameObject modifierButton = Instantiate (modifierButtonPrefab, modifierPane.transform);
			modifierButton.name = modifierString;
			modifierButton.GetComponentInChildren<Text>().text = modifierString;
		}
	}
}
