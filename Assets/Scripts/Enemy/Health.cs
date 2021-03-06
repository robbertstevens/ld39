﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float Energy = 100;

    public List<GameObject> loot;

    // Update is called once per frame
    void Update()
    {
        if (Energy > 0)
        {
            return;
        }

        if (loot.Count < 1)
        {
            return;
        }

        int r = Random.Range(0, loot.Count);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, -3);

        Instantiate(loot[r], pos, Quaternion.identity);
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
