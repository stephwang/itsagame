using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	private int health = 100;
	Text healthText;

	void Start() {
		healthText = GameObject.Find ("health").GetComponent<Text>();
		setHealthText ();
	}
		
	void setHealthText() {
		healthText.text = string.Format ("Health: {0}", health);
	}
}
