using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public enum PowerUp { Nothing, Shotgun }
	public PowerUp CurrentPowerUp = PowerUp.Nothing;
    public GameObject BulletLocation;

    public float delayShootingMSNormal = 0.1f;
	public float delayShootingMSShotgun = 0.25f;
	
	public float costNormal = 0.5f;	
	public float costShotgun = 1f;

    private float timeStampDelayShooting = 0f;
	
	public void ChangePowerUp(PowerUp PowerUpType){
		CurrentPowerUp = PowerUpType;
	}

	public float Shoot(float rotation){
		if (Time.time >= timeStampDelayShooting && Input.GetButton("Fire1") || Input.GetButtonDown("Fire1"))
        {
			switch (CurrentPowerUp)
			{
				case PowerUp.Shotgun:
					ShootShotGun(rotation);
					return costShotgun;
				case PowerUp.Nothing:
					ShootNormal(rotation);
					return costNormal;
				default:
				break;
			}
            
        }
		return 0;
	}

	private void ShootShotGun(float rotation){
		GameObject bullet1 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet1.transform.rotation = Quaternion.Euler(0, 0, rotation + 10);
		GameObject bullet2 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet2.transform.rotation = Quaternion.Euler(0, 0, rotation);
		GameObject bullet3 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet3.transform.rotation = Quaternion.Euler(0, 0, rotation - 10);

		timeStampDelayShooting = Time.time + delayShootingMSShotgun;
	}

	private void ShootNormal(float rotation){
		GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet.transform.rotation = Quaternion.Euler(0, 0, rotation);
		timeStampDelayShooting = Time.time + delayShootingMSNormal;
	}
}
