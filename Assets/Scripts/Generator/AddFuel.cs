﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour {
	void Add(float fuel) {
		gameObject.GetComponent<Fuel>().Amount += fuel;
	}
}
