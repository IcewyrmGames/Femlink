using UnityEngine;
using System.Collections;

public class DestructableWall : MonoBehaviour {
	public Animator animator;

	public void FireHit() {
		animator.SetTrigger("Damaged");
	}
}