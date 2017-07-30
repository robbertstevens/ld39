using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public enum PowerUp { Nothing, Shotgun, RapidFire, Sniper, BackFire }
	public PowerUp CurrentPowerUp = PowerUp.Nothing;
    public GameObject BulletLocation;

    public float delayShootingMSNormal = 0.1f;
	public float delayShootingMSShotgun = 0.25f;
    public float delayShootingMSRapid = 0.025f;
	public float delayShootingMSSniper = 0.5f;
	public float delayShootingMSBackfire = 0.5f;

	public float costNormal = 0.5f;	
	public float costShotgun = 1f;
	public float costRapid = 0.25f;	
	public float costSniper = 3f;	
	public float costBackfire = 0.5f;	

	public float speedNormal = 10f;
	public float speedShotgun = 10f;
	public float speedRapidFire = 10f;
	public float speedSniper = 30f;	
	public float speedBackfire = 10f;

	public float damageNormal = 10f;
	public float damageShotgun = 10f;
	public float damageRapidFire = 10f;
	public float damageSniper = 1000f;
	public float damageBackfire = 10f;

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
				case PowerUp.RapidFire:
					ShootNormal(rotation, delayShootingMSRapid, damageRapidFire, speedRapidFire);
					return costNormal;
				case PowerUp.Sniper:
					ShootNormal(rotation, delayShootingMSSniper, damageSniper, speedSniper);
					return costSniper;
				case PowerUp.BackFire:
					ShootBackfire(rotation);
					return costBackfire;
				case PowerUp.Nothing:
					ShootNormal(rotation, delayShootingMSNormal, damageRapidFire, speedRapidFire);
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
		bullet1.GetComponent<BulletScript>().speed = speedShotgun;
		bullet1.GetComponent<Damage>().Amount = damageShotgun;

		GameObject bullet2 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet2.transform.rotation = Quaternion.Euler(0, 0, rotation);
		bullet2.GetComponent<BulletScript>().speed = speedShotgun;
		bullet2.GetComponent<Damage>().Amount = damageShotgun;

		GameObject bullet3 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet3.transform.rotation = Quaternion.Euler(0, 0, rotation - 10);
		bullet3.GetComponent<BulletScript>().speed = speedShotgun;
		bullet3.GetComponent<Damage>().Amount = damageShotgun;

		timeStampDelayShooting = Time.time + delayShootingMSShotgun;
	}

	private void ShootBackfire(float rotation){
		GameObject bullet1 = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet1.transform.rotation = Quaternion.Euler(0, 0, rotation);
		bullet1.GetComponent<BulletScript>().speed = speedShotgun;
		bullet1.GetComponent<Damage>().Amount = damageShotgun;

		Vector2 backwardsPosition = transform.position - (BulletLocation.transform.position - transform.position);

		GameObject bullet2 = Instantiate(Resources.Load("Prefabs/Bullet"), new Vector3(backwardsPosition.x, backwardsPosition.y, BulletLocation.transform.position.z), BulletLocation.transform.rotation) as GameObject;
		bullet2.transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
		bullet2.GetComponent<BulletScript>().speed = speedBackfire;
		bullet2.GetComponent<Damage>().Amount = damageBackfire;

		timeStampDelayShooting = Time.time + delayShootingMSBackfire;
	}

	private void ShootNormal(float rotation, float delay, float damage, float speed){
		GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet"), BulletLocation.transform.position, BulletLocation.transform.rotation) as GameObject;
		bullet.transform.rotation = Quaternion.Euler(0, 0, rotation);
		bullet.GetComponent<BulletScript>().speed = speed;
		bullet.GetComponent<Damage>().Amount = damage;
		timeStampDelayShooting = Time.time + delay;
	}

}
