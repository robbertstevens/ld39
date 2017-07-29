using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float Energy = 100.0f;
	public float Speed = 10.0f;
	public float FireRate = 1.0f;
	public enum PlayerState { Alive, Dead }
	public PlayerState State = PlayerState.Alive;
	public GameObject PlayerSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (State)
		{
			case PlayerState.Alive:
				MovePlayer();
				RotateSprite();
				Shoot();
			break;
			case PlayerState.Dead:
			break;
			default:
			break;
		}
	}

	private void MovePlayer(){
		transform.Translate(new Vector2(0,1) * Speed * Input.GetAxis("Vertical") * Time.deltaTime);
		transform.Translate(new Vector2(1,0) * Speed * Input.GetAxis("Horizontal") * Time.deltaTime);
	}

	private void Shoot() {
		if(Input.GetButton("Fire1")){
			// DO SHOOTING
		}
	}

	private void RotateSprite() {
		float rotationDegree = GetRotation();
		PlayerSprite.transform.rotation = Quaternion.Euler(0,0,rotationDegree);
	}

	private float GetRotation(){
		if(Input.GetAxis("Vertical") > 0){
			if(Input.GetAxis("Horizontal") > 0){
				return 315.0f;
			}else if(Input.GetAxis("Horizontal") < 0) {
				return 45.0f;
			}
			return 0;
		}else if(Input.GetAxis("Vertical") < 0){
			if(Input.GetAxis("Horizontal") > 0){
				return 225.0f;
			}else if(Input.GetAxis("Horizontal") < 0) {
				return 135.0f;
			}
			return 180.0f;
		}else if(Input.GetAxis("Horizontal") != 0){
			if(Input.GetAxis("Horizontal") > 0){
				return 270.0f;
			}else if(Input.GetAxis("Horizontal") < 0) {
				return 90.0f;
			}
		}
		return PlayerSprite.transform.rotation.eulerAngles.z;
	}
}
