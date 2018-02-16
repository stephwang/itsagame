using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour {

    private Image abilitySprite;
    public Text abilityLabel;
    public Image cdMask;
    public bool isPrimarySet;
    public static bool isPrimarySetActive = true;

    public string abilityButton;
    public Ability ability;
    private float abilityCd;
    // private AudioSource abilityAudio;
    private float cd;
    private float cdLeft;

    void Start () {
        // TODO initialize ability buttons - from user save state?
        abilitySprite = GetComponent<Image>();
        // abilitySource = GetComponent<AudioSource> ();
        // abilitySprite.sprite = ability.aSprite;
        // abilityCd = ability.aCooldown;
        AbilityReady ();
        EnableAbility(isPrimarySet == isPrimarySetActive);
    }

    public void ChangeAbility(Ability newAbility, GameObject abilityHolder) {
        ability = newAbility;
        abilityCd = ability.aCooldown;
        abilitySprite.sprite = ability.aSprite;
        // abilityAudio.clip = ability.aSound;

        ability.Initialize(abilityHolder);
    }

    public void EnableAbility(bool enable) {
        abilitySprite.enabled = enable;
        abilityLabel.enabled = enable;
        cdMask.enabled = enable;
        
    }

    // Update is called once per frame
    void Update () {
        bool canUseAbility = (cdLeft <= 0);
        if (canUseAbility && isPrimarySet == isPrimarySetActive) {
            AbilityReady ();
            if (Input.GetButton (abilityButton) && !UIController.menuActive) {
                TriggerAbility ();
            }
        } else {
            Cooldown();
        }
    }

    private void AbilityReady(){
        cdMask.enabled = false;
    }

    private void Cooldown(){
        cdLeft -= Time.deltaTime;
        cdMask.fillAmount = (cdLeft / cd);
    }

    private void TriggerAbility(){
        cd = abilityCd;
        cdLeft = cd;
        cdMask.enabled = true;

        // abilityAudio.Play ();
        ability.TriggerAbility ();
    }
}