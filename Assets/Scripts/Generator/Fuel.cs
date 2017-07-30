using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

	public float Amount = 0;
	public bool HealingActive = false;
	private bool CoroutineStarted = false;
	public AudioClip GeneratorSound;
	public GameObject HealingAura;
	public void Add(float fuel) {
		Amount += fuel;
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
			AudioSource.PlayClipAtPoint(GeneratorSound, transform.position);
			Amount -= 1;
			HealingActive = true;
			yield return new WaitForSeconds(5f);
		}
		HealingActive = false;
		CoroutineStarted = false;
	}
}
