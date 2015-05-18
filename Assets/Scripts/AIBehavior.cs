using UnityEngine;
using System.Collections;

public class AIBehavior : MonoBehaviour {
	public CharacterMovement movement;
	public Animator animator;
	public Vector3 targetPosition;
	public bool playerSeen;
	public Vector3 playerPosition;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			playerSeen = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			playerPosition = other.transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			playerSeen = false;
		}
	}
}
