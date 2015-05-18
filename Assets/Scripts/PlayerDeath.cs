using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	void OnDestroy() {
		Application.LoadLevel(0);
	}
}
