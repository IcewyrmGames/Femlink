using UnityEngine;
using System.Collections;

public class Torch : PuzzleTrigger {
	public ParticleSystem particles;
	public bool Lit = false;

	void Start () {
		particles = GetComponent<ParticleSystem>();
	}

	void OnEnable() {
		if (Lit) {
			particles.Play();
		} else {
			particles.Stop();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Bolt b = other.GetComponent<Bolt>();
		if (b) {
			//the torch is lit but the bolt is not
			if (particles.isPlaying && !b.particles.isPlaying) {
				b.particles.Play();

			//the bolt is lit but the torch is not
			} else if (!particles.isPlaying && b.particles.isPlaying) {
				Ignite();
			}
		}
	}

	public override bool isTriggered() {
		return particles.isPlaying;
	}

	public void Ignite() {
		particles.Play();
		Lit = true;
	}
}
