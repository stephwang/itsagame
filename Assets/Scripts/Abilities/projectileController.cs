﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		Destroy(gameObject);
	}
}
