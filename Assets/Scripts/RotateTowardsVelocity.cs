using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateTowardsVelocity : MonoBehaviour {
	Rigidbody2D rb;
	bool collided = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		Vector2 v = rb.velocity;
 		float angle = Mathf.Atan2(v.y, -v.x) * Mathf.Rad2Deg;
 		transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
	}
}
