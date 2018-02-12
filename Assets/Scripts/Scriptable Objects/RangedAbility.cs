using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities / RangedAbility")]
public class RangedAbility : Ability {

	public int aDamage = 1f;
	public float aRange = 50f;
	public float aKnockback = 0f;
	public Color aColor = Color.white;

	private RangedShootTriggerable rcShoot;
}
