using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Ability/MeleeAttack")]
public class MeleeAttack : Ability {

    public int aDamage = 20;

    private MeleeAttackScript meleeAttackScript;

    public override void Initialize(GameObject abilityHolder) {
        meleeAttackScript = abilityHolder.GetComponent<MeleeAttackScript>();
    }

    public override void TriggerAbility() {
        meleeAttackScript.aDamage = aDamage;
        meleeAttackScript.animationName = this.name;
        meleeAttackScript.Hit();
    }
}