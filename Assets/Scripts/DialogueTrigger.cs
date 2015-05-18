using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	public bool runOnce;
	public Dialogue dialogue;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			dialogue.Begin();
			if (runOnce) {enabled = false;}
		}
	}
}
