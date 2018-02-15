using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Definition/ModifierDef")]
public class ModifierDef: ScriptableObject {

	public string mName = "New Modifier";
	public Sprite mSprite;
	public Color mColor;
}
