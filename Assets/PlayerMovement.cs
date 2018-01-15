using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		// Movement
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (inputX != 0 || inputY != 0) {
			Vector2 playerInputVector = new Vector2 (inputX, inputY);
			GetComponent<Rigidbody2D> ().velocity = playerInputVector * speed;
			anim.SetFloat ("faceX", inputX);
			anim.SetFloat ("faceY", inputY);
			anim.Play ("Walk");
		} else {
			anim.Play("Idle");
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		//Basic attack
		bool inputAttack = Input.GetKeyDown(KeyCode.Space);

		if (inputAttack == true) {
			anim.Play ("Attack");
		}
	}
}
