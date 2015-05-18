using UnityEngine;
using System.Collections;
using System;

public class DoorMover : MonoBehaviour {
	public PlayerInput input;
	public CharacterMovement movement;

	public bool isMoving;

	Hashtable tweenArgs = new Hashtable();

	void Start() {
		tweenArgs.Add("time", 1f);
		tweenArgs.Add("position", Vector3.zero);
		tweenArgs.Add("onstart", "StartAnimation");
		tweenArgs.Add("oncomplete", "EndAnimation");
		tweenArgs.Add("easetype", iTween.EaseType.linear);
	}

	public void MoveTo(Vector3 target) {
		isMoving = true;
		tweenArgs["position"] = target;
		iTween.MoveTo(gameObject, tweenArgs);
	}

	public void StartAnimation() {
		isMoving = true;
		input.canControl = false;
		movement.canMove = false;
	}

	public void EndAnimation() {
		isMoving = false;
		input.canControl = true;
		movement.canMove = true;
	}
}
