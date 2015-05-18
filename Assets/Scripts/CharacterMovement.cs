using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour {
	public bool canMove;
	public bool animateMovement;

	public Rigidbody2D rigidbody;
	public Animator animator;

	public float maxSpeed = 10f;
	public float maxForce = 10f;
	public Vector2 targetVelocity;
	public Vector2 facing;

	void Start () {
		//rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (animateMovement) {
			if (rigidbody.velocity.sqrMagnitude > .1f) {
				animator.SetBool("Walking", true);
			} else {
				animator.SetBool("Walking", false);
			}

			if (targetVelocity.sqrMagnitude > .1f) {
				if (Mathf.Abs(targetVelocity.x) >= Mathf.Abs(targetVelocity.y)) {
					facing = new Vector2(targetVelocity.x, 0);
				} else {
					facing = new Vector2(0, targetVelocity.y);
				}
			}

			animator.SetFloat("Horizontal", facing.x);
			animator.SetFloat("Vertical", facing.y);
		}
	}

	void FixedUpdate() {
		if (canMove) {
			Vector3 velocityForce = (targetVelocity*maxSpeed - rigidbody.velocity) * (rigidbody.mass/Time.fixedDeltaTime);
			if (velocityForce.magnitude > maxForce) {
				velocityForce = velocityForce.normalized*maxForce;
			}
			rigidbody.AddForce(velocityForce);
		}
	}
}
