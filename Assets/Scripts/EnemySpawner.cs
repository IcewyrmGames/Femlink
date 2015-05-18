using UnityEngine;
using System.Collections;

public class EnemySpawner : PuzzleTrigger {
	public GameObject prefab;
	public GameObject spawned;

	void OnEnable() {
		spawned = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
		spawned.transform.parent = transform.parent;
	}

	public override bool isTriggered() {
		return spawned == null;
	}
}
