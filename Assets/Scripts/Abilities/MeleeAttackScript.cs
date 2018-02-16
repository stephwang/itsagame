using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour {

	[HideInInspector] public int aDamage;
	[HideInInspector] public string animationName;
	private Animator anim;

	private void Start() {
		anim = GetComponentInChildren<Animator>();
	}

	public void Hit() {
		anim.SetTrigger(animationName);
	}
}
