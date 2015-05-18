using UnityEngine;
using System.Collections;

public class ViewBlocker : MonoBehaviour {
	SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			sprite.enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			sprite.enabled = true;
		}
	}
}
