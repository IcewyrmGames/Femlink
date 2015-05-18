using UnityEngine;
using System.Collections.Generic;

public class Interaction : MonoBehaviour {
	List<Interactor> interactors = new List<Interactor>();

	void OnTriggerEnter2D(Collider2D other) {
		Interactor i = other.GetComponent(typeof(Interactor)) as Interactor;
		if (i != null) interactors.Add(i);
	}

	void OnTriggerExit2D(Collider2D other) {
		Interactor i = other.GetComponent(typeof(Interactor)) as Interactor;
		if (i != null) {
			i.Deactivate();
			interactors.Remove(i);
		}
	}

	public bool Interact(Vector2 facing) {
		foreach (Interactor i in interactors) {
			if (i.facing == Vector2.zero) {
				if (Vector2.Angle(facing, i.position-transform.position) < 45f) {
					i.Activate();
					return true;
				}
			} else if (Vector2.Angle(facing, i.facing) < 45f) {
				i.Activate();
				return true;
			}
		}
		return false;
	}
}
