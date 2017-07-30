using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float Energy = 100;
	
	public List<GameObject> loot;

	void Awake() {
		//loot = new List<GameObject>();
	}
	// Update is called once per frame
	void Update () {
		if (Energy > 0) {
			return;
		}

		if(loot.Count < 1) {
			return;
		}

		int r = Random.Range(0, loot.Count);
		Instantiate(loot[r], transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != Tag.Bullet) 
		{
			return;
		}
		Energy -= collision.gameObject.GetComponent<Damage>().Amount;

	}
}
