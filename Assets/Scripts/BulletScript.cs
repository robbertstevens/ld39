using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public int Horizontal = 0;
	public int Vertical = 0;
	public float speed = 10.0f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
