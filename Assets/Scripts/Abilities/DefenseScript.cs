using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseScript : MonoBehaviour {

	[HideInInspector] public GameObject shieldPrefab;

	public void Defend() {
		GameObject shield = Instantiate(shieldPrefab, transform.position, transform.rotation);
	}

}
