using UnityEngine;
using System.Collections;

public class DestructableWall : MonoBehaviour {
	public ParticleSystem[] particles;
	public Animator[] animators;
	bool burning = false;

	public void FireHit() {
		if (!burning)
			StartCoroutine(Burn());
	}

	public IEnumerator Burn() {
		burning = true;

		foreach (Animator anim in animators) {
			anim.SetTrigger("Damaged");
		}
		foreach (ParticleSystem ps in particles) {
			ps.Play();
		}

		yield return new WaitForSeconds(4);

		Destroy(gameObject);
	}
}