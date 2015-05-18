using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject menu;

	void Awake() {
		menu.SetActive(false);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (menu.activeSelf == true) {
				Deactivate();
			} else {
				Activate();
			}
		}
	}

	public void Activate() {
		menu.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Deactivate() {
		menu.SetActive(false);
		Time.timeScale = 1f;
	}
}
