using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AbilitiesManager: MonoBehaviour {
	// Ability constants
	public AbilityConstants abilityConstants;

	// Ability selection
	private static int _selectedAbilityIndex = -1;
	private static string _selectedAbilityName;
	private static Sprite _selectedAbilitySprite;
	private static int _selectedModifierIndex = -1;
	private static string _selectedModifierName;
	private static Sprite _selectedModifierSprite;
	public static Ability _selectedSpell {
		get {
			if (_selectedAbilityIndex > -1 && _selectedModifierIndex > -1) {
				return AbilityConstants.ABILITYMATRIX[_selectedAbilityIndex][_selectedModifierIndex];
			} else {
				return null;
			}
		}
	}

	// Selected abilities
	public static Ability _primary;
	public static Ability _secondary;
	public static Ability _alternatePrimary;
	public static Ability _alternateSecondary;

	// Ability UI
	public AbilityController primaryAbilityController;
	public AbilityController secondaryAbilityController;
	public AbilityController alternatePrimaryAbilityController;
	public AbilityController alternateSecondaryAbilityController;
	public AbilityMenuButton primaryButton;
	public AbilityMenuButton secondaryButton;
	public AbilityMenuButton alternatePrimaryButton;
	public AbilityMenuButton alternateSecondaryButton;
	private static Image selectedIcon;
	private static Text selectedText;

	// Holder for ability scripts
	public GameObject abilityHolder;

	// Keep AbilitiesManager a singleton
	private static AbilitiesManager _instance;
	public static AbilitiesManager Instance { 
		get { return _instance; } 
	}

	private void Awake() { 
		// Enforce single instance
		if (_instance != null && _instance != this) 
		{ 
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

		// Find menu components before they get hidden
		selectedIcon = GameObject.Find("Selected Icon").GetComponent<Image>();
		selectedText = GameObject.Find("Selected Text").GetComponent<Text>();
	}

	public void updateSelectedAbility() {
		GameObject selection = EventSystem.current.currentSelectedGameObject;
		_selectedAbilityIndex = selection.GetComponent<ButtonProps>().index;
		_selectedAbilityName = selection.name;
		_selectedAbilitySprite = selection.GetComponent<Image>().sprite;

		updateSelectedInAbilityMenu();
	}

	public void updateSelectedModifier() {
		GameObject selection = EventSystem.current.currentSelectedGameObject;
		_selectedModifierIndex = selection.GetComponent<ButtonProps>().index;
		_selectedModifierName = selection.name;
		_selectedModifierSprite = selection.GetComponent<Image>().sprite;

		updateSelectedInAbilityMenu();
	}

	public void updateSelectedInAbilityMenu() {
		if (_selectedSpell) {
			selectedText.text = _selectedSpell.aName;
			selectedIcon.sprite = _selectedSpell.aSprite;
		} else {
			string placeholderString = "??? ???";
			Sprite placeholderSprite = null;
			if(_selectedAbilityIndex > -1) {
				placeholderString = "??? " + _selectedAbilityName;
				placeholderSprite = _selectedAbilitySprite;
			} else if (_selectedModifierIndex > -1) {
				placeholderString = _selectedModifierName + " ???";
				placeholderSprite = _selectedModifierSprite;
			}

			selectedText.text = placeholderString;
			selectedIcon.sprite = placeholderSprite;
		}
	}

	public void setPrimaryAbility() {
		_primary = _selectedSpell;
		primaryButton.UpdateAbilityButton(_primary.aSprite);
		updatePrimaryAbilityInUI();
	}

	public void setSecondaryAbility() {
		_secondary = _selectedSpell;
		secondaryButton.UpdateAbilityButton(_secondary.aSprite);
		updateSecondaryAbilityInUI();
	}

	public void setAlternatePrimaryAbility() {
		_alternatePrimary = _selectedSpell;
		alternatePrimaryButton.UpdateAbilityButton(_alternatePrimary.aSprite);
		updateAlternatePrimaryAbilityInUI();
	}

	public void setAlternateSecondaryAbility() {
		_alternateSecondary = _selectedSpell;
		alternateSecondaryButton.UpdateAbilityButton(_alternateSecondary.aSprite);
		updateAlternateSecondaryAbilityInUI();
	}

	public void switchAbilitySets() {
		AbilityController.isPrimarySetActive = !AbilityController.isPrimarySetActive;
		primaryAbilityController.EnableAbility(AbilityController.isPrimarySetActive);
		secondaryAbilityController.EnableAbility(AbilityController.isPrimarySetActive);
		alternatePrimaryAbilityController.EnableAbility(!AbilityController.isPrimarySetActive);
		alternateSecondaryAbilityController.EnableAbility(!AbilityController.isPrimarySetActive);
	}

	public void updatePrimaryAbilityInUI() {
		primaryAbilityController.ChangeAbility(_primary, abilityHolder);
	}

	public void updateSecondaryAbilityInUI() {
		secondaryAbilityController.ChangeAbility(_secondary, abilityHolder);
	}

	public void updateAlternatePrimaryAbilityInUI() {
		alternatePrimaryAbilityController.ChangeAbility(_alternatePrimary, abilityHolder);
	}

	public void updateAlternateSecondaryAbilityInUI() {
		alternateSecondaryAbilityController.ChangeAbility(_alternateSecondary, abilityHolder);
	}
}