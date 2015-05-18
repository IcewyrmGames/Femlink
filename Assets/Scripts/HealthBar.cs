using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Slider slider;
	public Health health;

	void Update () {
		slider.value = (float)health.curHealth/(float)health.maxHealth;
	}
}
