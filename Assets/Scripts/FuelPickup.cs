using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != Tag.Player){
			return;
		}

		collision.gameObject.GetComponent<PlayerController>().Fuel +=1;
		Destroy(this.gameObject);
	}
}
