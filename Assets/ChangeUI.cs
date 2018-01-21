using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour {

	GameObject abilityMenu;
	GameObject mainUI;
//	GameObject settingsMenu; TODO

	// Use this for initialization
	void Start () {
		abilityMenu = GameObject.Find ("Ability Menu");
		abilityMenu.SetActive (false);
		mainUI = GameObject.Find ("Main UI");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			ToggleAbilityMenu ();
		}
	}

	void ToggleAbilityMenu() {
		abilityMenu.SetActive (!abilityMenu.activeInHierarchy);
		mainUI.SetActive (!abilityMenu.activeInHierarchy);
	}
}
