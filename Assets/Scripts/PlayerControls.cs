﻿using UnityEngine;

public class PlayerControls : MonoBehaviour {

	// Elements
	Animator anim;

	// Public variables
	public float speed;

	// Keep Player a singleton
	private static PlayerControls _instance;
	public static PlayerControls Instance { 
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
	}

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (!UIController.menuActive) {
			// Keep character facing the mouse
			UpdateRotation();

			// Movement
			Walk();

			// Abilities
			SwitchAbilitySets ();
		}
	}

	// Rotates the character to face the mouse
	void UpdateRotation() {
		Vector3 mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 dir = mouseCoords - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		anim.SetFloat ("faceX", dir.x);
		anim.SetFloat ("faceY", dir.y);
	}

	// Move player transform and trigger walk animation
	void Walk() {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (inputX != 0 || inputY != 0) {
			Vector2 playerInputVector = new Vector2 (inputX, inputY);
			transform.Translate (playerInputVector * speed * Time.deltaTime);
			anim.SetBool ("walk", true);
		}
		else {
			anim.SetBool ("walk", false);
		}
	}

	void SwitchAbilitySets() {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			AbilitiesManager.Instance.switchAbilitySets ();
		}
	}
}