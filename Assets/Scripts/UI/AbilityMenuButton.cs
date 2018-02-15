using UnityEngine;
using UnityEngine.UI;

public class AbilityMenuButton : MonoBehaviour {

	private Image abilitySprite;

	void Start() {
		abilitySprite = GetComponent<Image>();
	}

	public void UpdateAbilityButton(Sprite sprite) {
		abilitySprite.sprite = sprite;
	}
}
