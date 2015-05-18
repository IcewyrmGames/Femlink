using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleEmitter))]
public class Bolt : MonoBehaviour {
	public int damage = 1;
	public float knockback = 4f;

	public GameObject inactive;

	public ParticleSystem particles;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag != "Reflection" || particles.isPlaying) {
			//apply damage if the collision object has health
			Health h = coll.gameObject.GetComponent<Health>();
			if (h) {
				h.ApplyDamage(damage, transform.position, knockback);
			}

			//instantiate the inactive bolt object
			GameObject i = Instantiate(inactive, transform.position, transform.rotation) as GameObject;
			i.transform.parent = coll.gameObject.transform;

			if (particles.isPlaying) {
				i.GetComponent<ParticleSystem>().Play();
			}

			DestructableWall dw = coll.gameObject.GetComponent<DestructableWall>();
			if (dw) {
				//Debug.Log("Hit Wall");
				if (particles.isPlaying) {
					dw.FireHit();
				}
			}

			//destroy this active bolt
			Destroy(gameObject);
		}
	}
}
