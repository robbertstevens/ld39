using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

	public float Amount = 0;
	
	public void Add(float fuel) {
		gameObject.GetComponent<Fuel>().Amount += fuel;
	}
}
