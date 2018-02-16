using System.Collections;
using UnityEngine;

public class RangedAttackScript : MonoBehaviour {

	[HideInInspector] public int aDamage;
	[HideInInspector] public float projectileSpeed;
	[HideInInspector] public float projectileLife;
	[HideInInspector] public GameObject projectilePrefab;

	public void Fire() {
		GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
		projectile.GetComponent<ProjectileController>().damage = aDamage;
		Vector3 velocity = projectile.transform.right * projectileSpeed;
		projectile.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity.x, velocity.y);

		Destroy(projectile, projectileLife); 
	}
}
