using System;
using UnityEngine;
using UnityEngine.UI;

public class abilityMenu : MonoBehaviour {
	public GameObject abilityButtonPrefab;
	public GameObject modifierButtonPrefab;
	public AbilityConstants abilityConstants;

	// Use this for initialization
	void Awake () {
		PopulateAbilityMenuPanes ();
	}
		
	void PopulateAbilityMenuPanes() {
		// Populate abilities
		GameObject abilityPane = GameObject.Find ("Abilities Pane");
		int numAbilities = abilityConstants.ABILITYLIST.Count;
		for (int i = 0; i < numAbilities; i++) {
			AbilityDef ability = abilityConstants.ABILITYLIST[i];
			GameObject abilityButton = Instantiate (abilityButtonPrefab, abilityPane.transform);
			abilityButton.name = ability.aName;
			abilityButton.GetComponent<Image>().sprite = ability.aSprite;
			abilityButton.GetComponent<ButtonProps>().index = i;
		}

		// Populate modifiers
		GameObject modifierPane = GameObject.Find ("Modifiers Pane");
		int numModifiers = abilityConstants.MODIFIERLIST.Count;
		for (int i = 0; i < numModifiers; i++) {
			ModifierDef modifier = abilityConstants.MODIFIERLIST[i];
			GameObject modifierButton = Instantiate (modifierButtonPrefab, modifierPane.transform);
			modifierButton.name = modifier.mName;
			Image buttonImage = modifierButton.GetComponent<Image>();
			buttonImage.sprite = modifier.mSprite;
			buttonImage.color = modifier.mColor;
			modifierButton.GetComponent<ButtonProps>().index = i;
		}
	}
}
