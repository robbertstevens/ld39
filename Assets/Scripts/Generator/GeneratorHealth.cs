using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHealth : MonoBehaviour {

	public float Hits = 4;

	// Update is called once per frame
	void Update() {
		if(Hits > 0) {
			return;
		}
		Destroy(gameObject.GetComponent<Fuel>().HealingAura);
		Destroy(gameObject);

	}
	void OnCollisionEnter2D(Collision2D collision) {
		if ( collision.gameObject.tag != Tag.Enemy) {
			return;
		}

		Hits -= 1;
	}
}
