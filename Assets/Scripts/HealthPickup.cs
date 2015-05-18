using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	public int healAmount;

	void OnTriggerEnter2D(Collider2D other) {
		Health h = other.GetComponent<Health>();
		if (h) {
			h.curHealth = Mathf.Clamp(healAmount + h.curHealth, 0, h.maxHealth);
			Destroy(gameObject);
		}
	}
}
