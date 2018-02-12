using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilitiesManager: MonoBehaviour {
	private static AbilitiesManager _instance;

	public static AbilitiesManager Instance 
	{ 
		get { return _instance; } 
	} 

	private void Awake() 
	{ 
		if (_instance != null && _instance != this) 
		{ 
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		//	DontDestroyOnLoad(this.gameObject);
	}

	// Mapped abilities
	public string primary;
	public string secondary;
	public string alternatePrimary;
	public string alternateSecondary;

	// Ability selection
	public string selectedAbility;
	public string selectedModifier;
	public string selectedSpell {
		get {
			return string.Concat (selectedModifier, ' ', selectedAbility);
		}
	}

	public void updateSelectedAbility() {
		selectedAbility = EventSystem.current.currentSelectedGameObject.name;
	}

	public void updateSelectedModifier() {
		selectedModifier = EventSystem.current.currentSelectedGameObject.name;
	}

	public void updateSelectedInAbilityMenu() {
		Text selectedText = GameObject.Find ("Selected Text").GetComponent<Text>();
		selectedText.text = selectedSpell;
	}

	public void setPrimaryAbility() {
		primary = selectedSpell;
	}

	public void setSecondaryAbility() {
		secondary = selectedSpell;
	}

	public void setAlternatePrimaryAbility() {
		alternatePrimary = selectedSpell;
	}

	public void setAlternateSecondaryAbility() {
		alternateSecondary = selectedSpell;
	}

	public void switchAbilitySets() {
		string newPrimary = alternatePrimary;
		string newSecondary = alternateSecondary;
		alternatePrimary = primary;
		alternateSecondary = secondary;
		primary = newPrimary;
		secondary = newSecondary;

		updatePrimaryAbilityInUI (primary);
		updateSecondaryAbilityInUI (secondary);
	}

	public void updatePrimaryAbilityInUI(string ability="") {
		if (ability == "") {
			ability = selectedSpell;
		}
		Text primaryAbilityText = GameObject.Find ("primary ability").GetComponent<Text>();
		primaryAbilityText.text = ability;
	}

	public void updateSecondaryAbilityInUI(string ability="") {
		if (ability == "") {
			ability = selectedSpell;
		}
		Text secondaryAbilityText = GameObject.Find ("secondary ability").GetComponent<Text>();
		secondaryAbilityText.text = ability;
	}
}