using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	public CharacterMovement character;
	public Animator animator;
	public Health health;
	public BoxCollider2D cast;

	public Vector3 targetPosition;
	public bool playerVisible;
	public float attackRange;
	public float seekTimeout;

	public LayerMask terrainLayers;

	void OnEnable() {
		StartCoroutine(Wander());
		StartCoroutine(Attack());
		StartCoroutine(DeathCheck());
	}

	void OnDisable() {
		StopAllCoroutines();
	}

	public IEnumerator Wander() {
		while (true) {
			//find a random point to walk to
			Vector2 direction = Random.insideUnitCircle;
			RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, direction, 5f, terrainLayers.value);
			//Debug.Log("Boxcast from "+transform.position.ToString());
			if (hit.collider) {
				targetPosition = hit.centroid;
				if (hit.distance < .5f) {
					targetPosition += (Vector3)hit.normal;
				}
			} else {
				targetPosition = (Vector2)transform.position + direction * 5f;
			}

			//walk to that point
			yield return StartCoroutine(Seek());

			//stand there for 2 seconds
			yield return StartCoroutine(Wait(2f));
		}
	}

	public IEnumerator Seek() {
		float seekTime = 0f;
		//Debug.Log(targetPosition);
		while (Vector3.Distance(targetPosition, transform.position) > .1f) {
			if (seekTime > seekTimeout) break;
			if (!playerVisible) seekTime += Time.deltaTime;

			character.targetVelocity = (targetPosition - transform.position).normalized;
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
		while (elapsed < seconds && !playerVisible) {
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
