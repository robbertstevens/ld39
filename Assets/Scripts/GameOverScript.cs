using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

	public GameObject Visible;
	public PlayerController PlayerScript;

	// Update is called once per frame
	void Update () {
		if(!Visible.activeSelf && PlayerScript.State == PlayerController.PlayerState.Dead){
			Visible.SetActive(true);
		}

		if(Visible.activeSelf && Input.anyKey){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
