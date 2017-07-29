using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float Energy = 100.0f;
	public float MaxEnergy = 100.0f;
	public float Speed = 10.0f;
	public float FireRate = 1.0f;
	public float bulletCost = 0.5f;

	public float Fuel = 0.0f;
	public float MaxFuel = 100.0f;
	
	public enum PlayerState { Alive, Dead }
	public PlayerState State = PlayerState.Alive;
	public GameObject PlayerSprite; 

    public float delayShootingMS = 0.1f;

    private float timeStampDelayShooting = 0f;
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case PlayerState.Alive:
                MovePlayer();
                RotateSprite();
                Shoot();
                CheckHealth();
                break;
            case PlayerState.Dead:
                KillPlayer();
                break;
            default:
                break;
        }

    }

    private void MovePlayer()
    {
        Vector2 towardsPosition = (new Vector2(0, 1) * Input.GetAxis("Vertical")) + (new Vector2(1, 0) * Input.GetAxis("Horizontal"));
        rigidBody.AddForce(towardsPosition * Speed);
    }

    private void Shoot()
    {
        if (Time.time >= timeStampDelayShooting && Input.GetButton("Fire1") || Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation) as GameObject;
            bullet.transform.rotation = Quaternion.Euler(0, 0, PlayerSprite.transform.rotation.eulerAngles.z);
            timeStampDelayShooting = Time.time + delayShootingMS;
            Energy -= bulletCost;
        }
    }

    private void CheckHealth()
    {
        if (Energy <= 0)
        {
            State = PlayerState.Dead;
        }
    }

    private void KillPlayer()
    {
        Destroy(this.gameObject);
    }

	private void RotateSprite() {
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(PlayerSprite.transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		PlayerSprite.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
	}
}
