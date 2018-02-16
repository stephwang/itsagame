using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Damageable {

	public int damage;
	public int moveSpeed;

	private GameObject player;
	private PlayerHealth playerHealth;

	public override void Awake() {
		base.Awake();
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == player) {
			playerHealth.TakeDamage(damage);
		}
	}

	private void Update() {
		Move();
	}

	private void Move() {
		Quaternion travelRotation = Quaternion.LookRotation(player.transform.position - transform.position);
		Vector3 travelVector = travelRotation * Vector3.forward;
		
		transform.position += travelVector * moveSpeed * Time.deltaTime;
	}
}