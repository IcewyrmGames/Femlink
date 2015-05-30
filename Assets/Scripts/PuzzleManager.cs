using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PuzzleManager : MonoBehaviour {
	public bool triggerOnce;
	public PuzzleTrigger[] triggers;

	public UnityEvent OnTriggered;
	public UnityEvent OnReset;

	bool _triggered;
	public bool triggered {
		get {return _triggered;}
		set {
			if (value == _triggered) return;
			_triggered = value;
			if (_triggered) {
				OnTriggered.Invoke();
			} else {
				OnReset.Invoke();
			}

			if (_triggered && triggerOnce) Destroy (gameObject);
		}
	}

	void Update() {
		bool alltriggers = true;
		foreach (PuzzleTrigger trig in triggers) {
			if (!trig.isTriggered()) {
				alltriggers = false;
			}
		}
		triggered = alltriggers;
	}
}
