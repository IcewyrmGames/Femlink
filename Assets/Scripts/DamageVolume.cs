using UnityEngine;
using System.Collections;

public class DamageVolume : MonoBehaviour {
	public int damage;

	public float knockback;
	public Vector3 center;

	void OnTriggerStay2D(Collider2D other) {
		Health h = other.GetComponent<Health>();
		if (h && h.invulnerable == false) {
			h.ApplyDamage(damage, transform.position + center, knockback);
		}
	}
}
