using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityConstants: MonoBehaviour {

	public List<AbilityDef> ABILITYLIST;
	public List<ModifierDef> MODIFIERLIST;

	// Abilities
	public Ability fireSword;
	public Ability waterSword;
	public Ability iceSword;
	public Ability fireBow;
	public Ability waterBow;
	public Ability iceBow;
	public Ability fireShield;
	public Ability waterShield;
	public Ability iceShield;

	public static List<List<Ability>> ABILITYMATRIX;

	void Awake() {
		Debug.Log("Populating Ability Matrix");
		ABILITYMATRIX = new List<List<Ability>> {
			new List<Ability> {fireSword, waterSword, iceSword},
			new List<Ability> {fireBow, waterBow, iceBow},
			new List<Ability> {fireShield, waterShield, iceShield}
		};
	}
}
