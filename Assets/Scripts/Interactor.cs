using UnityEngine;
using System.Collections;

public interface Interactor {
	Vector2 facing {get;}
	Vector3 position {get;}

	void Activate();
	void Deactivate();
}
