using UnityEngine;
using System.Collections;

public class SpriteYOrdering : MonoBehaviour {
	public bool sortOnStartup = true;
	public bool sortOnUpdate = false;

	public int precision = 4;

	SpriteRenderer renderer;
	
	void Start () {
		renderer = GetComponent<SpriteRenderer>();

		if (sortOnStartup) {
			Sort();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sortOnUpdate) {
			Sort();
		}
	}

	[ContextMenu("Sort")]
	void Sort() {
		renderer.sortingOrder = -Mathf.FloorToInt(transform.position.y * precision);
	}
}
