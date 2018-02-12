using UnityEngine;

public class UIController : MonoBehaviour {

	GameObject abilityMenu;
//	GameObject mainUI;
//	GameObject settingsMenu; TODO

	// Use this for initialization
	void Start () {
		abilityMenu = GameObject.Find ("Ability Menu");
		abilityMenu.SetActive (false);
//		mainUI = GameObject.Find ("Main UI");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			ToggleAbilityMenu ();
		}

		else if (Input.GetKeyDown(KeyCode.Escape)) {
			ReturnToMainUI();
		}
	}

	void ToggleAbilityMenu() {
		abilityMenu.SetActive (!abilityMenu.activeInHierarchy);
	}

	void ReturnToMainUI() {
		abilityMenu.SetActive (false);
	}
}
