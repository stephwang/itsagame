using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aCooldown = 1f;

    public abstract void Initialize(GameObject abilityHolder);
    public abstract void TriggerAbility();
}