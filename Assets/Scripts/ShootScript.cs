using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public enum PowerUp { Nothing, Shotgun }
	public PowerUp CurrentPowerUp = PowerUp.Nothing;

	public void ChangePowerUp(PowerUp PowerUpType){
		CurrentPowerUp = PowerUpType;
	}
}
