using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyEnemy : MonoBehaviour {

	public float jumpDistance = 2000;
	public float delayJump = 3f;
	public float timeStampJump;
	private Rigidbody2D rigidBody;

    void Awake()
    {
		timeStampJump = Time.time + delayJump;
        rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
		if(Time.time > timeStampJump){
			Vector2 direction;
			int random = Random.Range(0, 4);
			if(random <= 0){
				direction = Vector3.left;
			}else if(random <= 1 ){
				direction = Vector3.right;
			}else if(random <= 2 ){
				direction = Vector3.up;
			}else{
				direction = Vector3.down;
			}
			
			rigidBody.AddForce(direction * jumpDistance);
			timeStampJump = Time.time + delayJump;
		}
	}
}
