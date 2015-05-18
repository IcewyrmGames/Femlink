using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueView : MonoBehaviour {
	//text box
	public bool showText {
		set {
			if (headerText) headerText.enabled = value;
			if (bodyText) bodyText.enabled = value;
			if (textBounds) textBounds.enabled = value;
		}
	}
	public Text headerText;
	public Text bodyText;
	public Image textBounds;

	//sprite displayer
	public bool showLeftSprite {
		set {
			if (leftimage) leftimage.enabled = value;
		}
	}
	public Image leftimage;

	public bool showRightSprite {
		set {
			if (rightimage) rightimage.enabled = value;
		}
	}
	public Image rightimage;

	//movie displayer
	public bool showMovie {
		set {
			if (screen) screen.enabled = value;
			if (speakers) speakers.enabled = value;
		}
	}
	public RawImage screen;
	public AudioSource speakers;

	void Awake() {
		showText = false;
		showLeftSprite = false;
		showRightSprite = false;
		showMovie = false;
	}
}
