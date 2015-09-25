using UnityEngine;
using System.Collections;

public class DamageTotem : Health {
	public Health otherHealth;
	public int totemHealth = 3;
	public bool isDamaged = false;

	int curTotemHealth;
	public Collider2D coll;

	public void Start() {
		curTotemHealth = totemHealth;
		coll = GetComponent<Collider2D>();
	}

	public override void ApplyDamage(int amount, Vector3 origin, float knockback) {
		isDamaged = true;

		if (curTotemHealth <= 0) {
			otherHealth.indelible = false;
			gameObject.SetActive(false);
		} else {
			curTotemHealth--;
			coll.enabled = false;
		}
	}
}
