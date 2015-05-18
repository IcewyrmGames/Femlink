using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public Animator door1;
	public Animator door2;

	public void Open() {
		door1.SetTrigger("Open");
		door1.ResetTrigger("Close");
		door2.SetTrigger("Open");
		door2.ResetTrigger("Close");
	}

	public void Close() {
		door1.SetTrigger("Close");
		door1.ResetTrigger("Open");
		door2.SetTrigger("Close");
		door2.ResetTrigger("Open");
	}
}