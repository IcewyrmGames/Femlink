using UnityEngine;
using System.Collections;

public class PuzzlePadTrigger : PuzzleTrigger {
	public enum Type {Character, Object, Enemy};
	public Type type;
	public GameObject obj;

	public override bool isTriggered() {
		Collider2D[] cols = Physics2D.OverlapPointAll(transform.position);
		if (type == Type.Character) {
			foreach (Collider2D col in cols) {
				if (col.tag == "Player") return true;
			}
		} else if (type == Type.Enemy) {
			foreach (Collider2D col in cols) {
				if (col.tag == "Enemy") return true;
			}
		} else if (obj) {
			foreach (Collider2D col in cols) {
				if (col.gameObject == obj) return true;
			}
		}
		return false;
	}
}
