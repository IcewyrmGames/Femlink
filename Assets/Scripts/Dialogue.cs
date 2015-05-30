using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {
	public DialogueView view;
	public bool beginOnStart;

	public List<DialogueNode> nodes;

	public UnityEvent OnComplete;

	void Start() {
		if (beginOnStart) Begin();
	}

	public void Begin() {
		StopAllCoroutines();
		view.showText = false;
		view.showLeftSprite = false;
		view.showRightSprite = false;
		view.showMovie = false;
		StartCoroutine( RunDialogue() );
	}

	IEnumerator RunDialogue() {
		Debug.Log("Dialogue Begin");
		Time.timeScale = 0f;
		foreach (DialogueNode node in nodes) {
			if (node.type == DialogueNode.NodeType.text) {
				yield return StartCoroutine( TextNode(node) );
			} else if (node.type == DialogueNode.NodeType.movie) {
				yield return StartCoroutine( MovieNode(node) );
			} else {
				yield return StartCoroutine( MovementNode(node) );
			}
			yield return null;
		}
		Debug.Log("Dialogue End");
		Time.timeScale = 1f;
		OnComplete.Invoke();
	}

	IEnumerator TextNode(DialogueNode node) {
		Debug.Log("TextNode Begin");

		if (!string.IsNullOrEmpty(node.text)) {
			view.showText = true;
			view.bodyText.text = node.text;
			view.headerText.text = node.header;
		} else {view.showText = false;}

		if (node.leftSprite) {
			view.showLeftSprite = true;
			view.leftimage.sprite = node.leftSprite;
		} else {view.showLeftSprite = false;}

		if (node.rightSprite) {
			view.showRightSprite = true;
			view.rightimage.sprite = node.rightSprite;
		} else {view.showRightSprite = false;}

		yield return StartCoroutine( WaitInterrupt(10f) );

		view.showText = false;
		view.showLeftSprite = false;
		view.showRightSprite = false;

		Debug.Log("TextNode End");
	}

	IEnumerator MovieNode(DialogueNode node) {
		Debug.Log("MovieNode Begin");
		view.showMovie = true;
		view.screen.texture = node.movie;
		view.speakers.clip = node.movieAudio;
		node.movie.Play();
		view.speakers.Play();
		yield return StartCoroutine( WaitInterrupt(node.movieAudio.length) );
		node.movie.Stop();
		view.speakers.Stop();
		view.showMovie = false;
		Debug.Log("MovieNode End");
	}

	IEnumerator MovementNode(DialogueNode node) {
		Debug.Log("MoveNode Begin");
		Hashtable table = new Hashtable();
		table.Add("ignoretimescale", true);
		table.Add("position", node.position);
		table.Add("islocal", true);
		table.Add("easetype", iTween.EaseType.linear);
		table.Add("time", node.moveTime);
		iTween.MoveTo(node.obj, table);
		yield return StartCoroutine( WaitInterrupt(node.moveTime) );
		Debug.Log("MoveNode End");
	}

	IEnumerator WaitInterrupt(float seconds) {
		float elapsed = 0;
		while (elapsed < seconds && !Input.GetButtonDown("Fire1") && !Input.GetMouseButtonDown(0)) {
			elapsed += Time.unscaledDeltaTime;
			yield return null;
		}
		//Debug.Log("Wait Ended");
	}
}

[System.Serializable]
public class DialogueNode {
	public enum NodeType {text, movie, movement};
	public NodeType type;

	//display a sprite in the UI
	public Sprite leftSprite;
	public Sprite rightSprite;

	//display some text
	public string header;
	[TextArea] public string text;

	//display a movie
	public MovieTexture movie;
	public AudioClip movieAudio;

	//move an object
	public GameObject obj;
	public Vector3 position;
	public float moveTime;
}