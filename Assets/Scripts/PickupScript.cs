using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	public enum PickupType {
		Fuel,
		Shotgun
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
				ShotgunBehavoir(collider);
				break;
			default:
				break;
		}

		Destroy(this.gameObject);
	}

	void ShotgunBehavoir(Collider2D collider){
		collider.gameObject.GetComponent<PlayerController>().ChangePowerUp(ShootScript.PowerUp.Shotgun);
	}

	void FuelBehavoir(Collider2D collider){
		collider.gameObject.GetComponent<PlayerController>().Fuel +=1;
	}
}
