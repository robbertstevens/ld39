using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float Amount = 10;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == Tag.Player) {
			return;
		}
		Destroy(this.gameObject);
	}
}
