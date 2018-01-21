using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Elements
	Animator anim;

	// Public variables
	public float speed;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		// Keep character facing the mouse
		UpdateRotation();

		// Movement
		Walk();

		//Basic attack
		bool inputAttack = Input.GetKeyDown(KeyCode.Space);
		if (inputAttack == true) {
			Debug.Log ("attack!");
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
			transform.Translate (playerInputVector * speed);
			anim.SetBool ("walk", true);
		}
		else {
			anim.SetBool ("walk", false);
		}
	}
}