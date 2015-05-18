using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Vector3 target;

	void OnTriggerEnter2D(Collider2D other) {
		DoorMover mover = other.GetComponent<DoorMover>();
		if (mover && !mover.isMoving) {
			mover.MoveTo(transform.TransformPoint(target));
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.TransformPoint(target));
	}
}
