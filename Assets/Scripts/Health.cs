using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth = 10;
	public int curHealth = 8;

	public bool invulnerable = false;

	public Animator animator;
	public Rigidbody2D rigidbody;

	void Start () {
		//animator = GetComponent<Animator>();
	}

	void OnEnable() {
		curHealth = maxHealth;
	}

	public void ApplyDamage(int amount, Vector3 origin, float knockback) {
		if (invulnerable) return;
		invulnerable = true;

		curHealth -= amount;
		
		animator.SetTrigger("Damaged");
		if (curHealth <= 0) {
			animator.SetBool("Dead", true);
		}

		//push the character back with a physics impulse
		Vector3 force = (transform.position - origin).normalized*knockback;
//		animator.SetFloat("ImpactX", force.x);
//		animator.SetFloat("ImpactY", force.y);
		rigidbody.AddForce(force, ForceMode.Impulse);
	}
}
