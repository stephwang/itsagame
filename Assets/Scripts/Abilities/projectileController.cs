using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : AttackController {

	public override void OnTriggerEnter2D (Collider2D other) {
		base.OnTriggerEnter2D(other);

        Destroy(gameObject);
	}
}
