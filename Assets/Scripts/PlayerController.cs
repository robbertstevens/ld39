using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float Energy = 100.0f;
	public float Speed = 10.0f;
	public float FireRate = 1.0f;
	public enum PlayerState { Alive, Dead }
	public PlayerState State = PlayerState.Alive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (State)
		{
			case PlayerState.Alive:
				MovePlayer();
				Shoot();
			break;
			case PlayerState.Dead:
			break;
			default:
			break;
		}
	}

	public void MovePlayer(){
		transform.Translate(new Vector2(0,1) * Speed * Input.GetAxis("Vertical") * Time.deltaTime);
		transform.Translate(new Vector2(1,0) * Speed * Input.GetAxis("Horizontal") * Time.deltaTime);
	}

	public void Shoot() {
		if(Input.GetButton("Fire")){
			// DO SHOOTING
		}
	}
}
