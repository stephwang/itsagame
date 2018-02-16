using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	public int totalHealth;
	public int _currentHealth;

	public virtual void Awake() {
		_currentHealth = totalHealth;
	}

	public virtual void TakeDamage(int damage) {
		_currentHealth -= damage;

		if(_currentHealth <= 0) {
			Die();
		}
	}

	public virtual void Die() {
		Destroy(gameObject);
	}
}
