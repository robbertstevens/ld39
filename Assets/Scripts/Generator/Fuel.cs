﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

	public float Amount = 0;
	public bool HealingActive = false;
	private bool CoroutineStarted = false;

	public GameObject HealingAura;
	public void Add(float fuel) {
		gameObject.GetComponent<Fuel>().Amount += fuel;
	}
	void Awake() {
		HealingAura = Instantiate(HealingAura, transform.position, Quaternion.identity);
		HealingAura.GetComponent<HealPlayer>().Generator = gameObject;
		HealingAura.SetActive(HealingActive);
	}
	void Update() {
		if (Amount > 0 && !CoroutineStarted) {
			StartCoroutine("GenerateEnergy");
			CoroutineStarted = true;
		} 

		HealingAura.SetActive(HealingActive);

	}

	IEnumerator GenerateEnergy() {
		while(Amount > 0) {
			Amount -= 1;
			HealingActive = true;
			yield return new WaitForSeconds(5f);
		}
		HealingActive = false;
		CoroutineStarted = false;
	}
}
