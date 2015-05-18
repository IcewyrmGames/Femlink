using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public bool canControl;

	public CharacterMovement movement;
	public Animator animator;
	public Interaction interaction;

	Vector2 inputDirection;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			canControl = !canControl;
		}

		if (!canControl) {
			inputDirection = Vector2.zero;
		} else {
			inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
		movement.targetVelocity = inputDirection.normalized;

		if (Input.GetButtonDown("Fire1")) {
			if (interaction.Interact(movement.facing)) {
				animator.SetTrigger("Interacting");
			} else {
				animator.SetTrigger("Melee");
			}

		} else if (Input.GetButtonDown("Fire2")) {
			animator.SetTrigger("Ranged");
		}
	}
}
