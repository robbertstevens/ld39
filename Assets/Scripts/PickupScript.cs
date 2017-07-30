using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	public enum PickupType {
		Fuel,
		Shotgun,
		RapidFire
	}
	
	public PickupType PrefabPickupType;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag != Tag.Player){
			return;
		}

		switch (PrefabPickupType)
		{
			case PickupType.Fuel:
				FuelBehavoir(collider);
				break;
			case PickupType.Shotgun:
				PowerUpBehavoir(collider, ShootScript.PowerUp.Shotgun);
				break;
			case PickupType.RapidFire:
				PowerUpBehavoir(collider, ShootScript.PowerUp.RapidFire);
				break;
			default:
				break;
		}

		Destroy(this.gameObject);
	}

	void PowerUpBehavoir(Collider2D collider, ShootScript.PowerUp type){
		collider.gameObject.GetComponent<PlayerController>().ChangePowerUp(type);
	}

	void FuelBehavoir(Collider2D collider){
		collider.gameObject.GetComponent<PlayerController>().Fuel +=1;
	}
}
