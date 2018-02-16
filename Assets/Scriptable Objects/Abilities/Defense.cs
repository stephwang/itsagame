using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Ability/Defense")]
public class Defense : Ability {
    
    public float aDuration;
    public GameObject shieldPrefab;
    public bool staysOnPlayer;

    private DefenseScript defenseScript;

    public override void Initialize(GameObject abilityHolder) {
        defenseScript = abilityHolder.GetComponent<DefenseScript>();
    }

    public override void TriggerAbility() {
        defenseScript.Defend();
    }
}