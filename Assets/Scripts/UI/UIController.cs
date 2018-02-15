using UnityEngine;

public class UIController : MonoBehaviour {

	public GameObject abilityMenu;
	public GameObject mainUI;
	public GameObject settingsMenu; //TODO
	public static bool menuActive;

	// Keep GameManager a singleton
	private static UIController _instance;

	public static UIController Instance 
	{ 
		get { return _instance; } 
	}

	private void Awake() 
	{ 
		// Enforce single instance
		if (_instance != null && _instance != this) 
		{ 
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		abilityMenu.SetActive (false);
		settingsMenu.SetActive (false);
		menuActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab) && !settingsMenu.activeInHierarchy) {
			ToggleAbilityMenu ();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && !abilityMenu.activeInHierarchy) {
			ToggleSettingsMenu();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && menuActive) {
			ReturnToMainUI();
		}
	}

	void ToggleAbilityMenu() {
		abilityMenu.SetActive (!abilityMenu.activeInHierarchy);
		menuActive = abilityMenu.activeInHierarchy;
	}

	void ToggleSettingsMenu() {
		settingsMenu.SetActive (!settingsMenu.activeInHierarchy);
		menuActive = settingsMenu.activeInHierarchy;
	}

	void ReturnToMainUI() {
		abilityMenu.SetActive (false);
		settingsMenu.SetActive(false);
		menuActive = false;
	}
}
