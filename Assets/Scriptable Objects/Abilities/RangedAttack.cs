using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Ability/RangedAttack")]
public class RangedAttack : Ability {

    public int aDamage = 10;
    public float projectileSpeed = 5f;
    public float projectileLife = 2.0f;
    public GameObject projectilePrefab;

    private RangedAttackScript rangedAttackScript;

    public override void Initialize(GameObject abilityHolder) {
        rangedAttackScript = abilityHolder.GetComponent<RangedAttackScript>();
    }

    public override void TriggerAbility() {
        rangedAttackScript.aDamage = aDamage;
        rangedAttackScript.projectileSpeed = projectileSpeed;
        rangedAttackScript.projectileLife = projectileLife;
        rangedAttackScript.projectilePrefab = projectilePrefab;
        rangedAttackScript.Fire();
    }
}