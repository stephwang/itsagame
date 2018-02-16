using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour {

	[HideInInspector] public int aDamage;
	[HideInInspector] public string animationName;
	private Animator anim;
	private AttackController attackController;

	private void Start() {
		anim = GetComponentInChildren<Animator>();
		attackController = GetComponentInChildren<AttackController>();
	}

	public void Hit() {
		attackController.damage = aDamage;
		anim.SetTrigger(animationName);
	}
}
