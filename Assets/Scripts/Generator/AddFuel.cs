using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2d(Collision2D collision) 
	{
		if (collision.gameObject.tag != Tag.Player) {
			return;
		}

		GameObject player = collision.gameObject;

		int fuel = player.GetComponent<PlayerController>().Fuel;
		while (fuel > 0) {
			gameObject.GetComponent<AddEnergyToPlayer>().AddFuel(fuel--);
		}
	}
}
