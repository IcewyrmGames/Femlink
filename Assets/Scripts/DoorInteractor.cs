using UnityEngine;
using System.Collections;

public class DoorInteractor : MonoBehaviour, Interactor {
	public DoorController controller;

	public Vector2 facing {
		get {return Vector2.zero;}
	}
	public Vector3 position {
		get {return transform.position;}
	}

	public void Activate() {
		controller.Open();
	}

	public void Deactivate() {
		controller.Close();
	}
}
