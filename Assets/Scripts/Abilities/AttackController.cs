using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

	public int damage;

	public virtual void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyBehavior>().TakeDamage(damage);
		}
	}
}
