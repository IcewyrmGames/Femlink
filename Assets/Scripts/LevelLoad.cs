using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {
	public string levelName;

	public void Load() {
		Application.LoadLevel(levelName);
	}
}