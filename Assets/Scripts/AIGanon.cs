using UnityEngine;
using System.Collections;

public class AIGanon : MonoBehaviour {
	public Transform player;
	public DamageTotem totem;
	public Transform[] appearPositions;
	public CharacterMovement character;
	public Animator animator;
	public Health health;
	
	public Vector3 targetPosition;
	public bool playerVisible;
	public float attackRange;
	public float seekTimeout;
	
	public LayerMask terrainLayers;
	
	void OnEnable() {
		StartCoroutine(Appear());
		StartCoroutine(Attack());
		StartCoroutine(DeathCheck());
	}
	
	void OnDisable() {
		StopAllCoroutines();
	}
	
	public IEnumerator Appear() {
		Transform lastPoint = appearPositions[0];
		Transform point = appearPositions[0];
		while (true) {
			while (lastPoint.Equals(point)) {
				point = appearPositions[Random.Range(0, appearPositions.Length)];
			}
			character.transform.position = point.position;
			totem.transform.position = point.position;
			totem.isDamaged = false;
			totem.coll.enabled = true;

			lastPoint = point;

			yield return StartCoroutine(Seek());
			yield return StartCoroutine(Wait(2f));
		}
	}
	
	public IEnumerator Seek() {
		while (!totem.isDamaged) { //while Ganon's totem hasn't taken damage
			character.targetVelocity = (player.position - transform.position).normalized;
			yield return null;
		}
		character.targetVelocity = Vector2.zero;
	}
	
	public IEnumerator Attack() {
		while (true) {
			if (playerVisible && Vector3.Distance(transform.position, targetPosition) < attackRange) {
				yield return new WaitForSeconds(.5f);
				animator.SetTrigger("Melee");
				yield return new WaitForSeconds(.5f);
			}
			yield return null;
		}
	}
	
	public IEnumerator DeathCheck() {
		while (true) {
			if (animator.GetBool("Dead")) {
				character.targetVelocity = Vector2.zero;
				StopAllCoroutines();
			}
			yield return null;
		}
	}
	
	public IEnumerator Wait(float seconds) {
		float elapsed = 0f;
		while (elapsed < seconds) {
			elapsed += Time.deltaTime;
			yield return null;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			playerVisible = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			targetPosition = other.transform.position;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			playerVisible = false;
		}
	}
}