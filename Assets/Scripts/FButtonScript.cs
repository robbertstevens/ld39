using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonScript : MonoBehaviour {

	public PlayerController PlayerScript;
	public GameObject display;

	// Update is called once per frame
	void Update () {
		if(!display.activeSelf && PlayerScript.InRangeOfGenerator){
			display.SetActive(true);
		}else if(display.activeSelf && !PlayerScript.InRangeOfGenerator){
			display.SetActive(false);
		}
	}
}
