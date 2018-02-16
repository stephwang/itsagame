using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable {

	public Text healthText;
	public static bool isDead = false;

	void Start() {
		setHealthText ();
	}
		
	void setHealthText() {
		healthText.text = string.Format ("Health: {0}", _currentHealth);
	}

	public override void TakeDamage(int damage) {
		_currentHealth -= damage;
		setHealthText();

		if(_currentHealth <= 0) {
			Die();
		}
	}

	public override void Die() {
		isDead = true;
		Debug.Log("YOU'RE DEAD! GAME OVER!");
	}
}
