using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
	void OnDisable() {
		Destroy(gameObject);
	}
}
