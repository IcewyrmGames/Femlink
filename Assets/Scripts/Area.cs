using UnityEngine;
using System.Collections.Generic;

public class Area : MonoBehaviour {
	public GameObject[] targets;
	public SpriteRenderer[] sprites;

	void Start() {
		foreach (GameObject target in targets) {
			target.SetActive(false);
		}
		foreach (SpriteRenderer sr in sprites) {
			sr.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Player") return;

		foreach (GameObject target in targets) {
			target.SetActive(true);
		}
		foreach (SpriteRenderer sr in sprites) {
			sr.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag != "Player") return;

		foreach (GameObject target in targets) {
			target.SetActive(false);
		}
		foreach (SpriteRenderer sr in sprites) {
			sr.enabled = false;
		}
	}
}
