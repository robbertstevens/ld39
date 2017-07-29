using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour {

	public bool HealthBar = true;
	public float Size; 
	public GameObject Player;
	public RectTransform percentageBar;
	private PlayerController PlayerController;

	// Use this for initialization
	void Start () {
		PlayerController = Player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(HealthBar){
			float percentage = PlayerController.Energy / PlayerController.MaxEnergy;
			percentageBar.sizeDelta = new Vector2(Size * percentage, percentageBar.sizeDelta.y);
		}else{
			float percentage = PlayerController.Fuel / PlayerController.MaxFuel;
			percentageBar.sizeDelta = new Vector2(Size * percentage, percentageBar.sizeDelta.y);
		}
	}
}
