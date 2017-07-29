using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnergyToPlayer : MonoBehaviour
{
    private int energy = 0;

    public int FuelRatio = 10;
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Healing Player");
        if (collision.gameObject.tag != Tag.Player)
        {
            return;
        }
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        player.Energy += HealPlayer();
    }

    private int HealPlayer()
    {
        return energy--;
    }

    public void AddFuel(int fuel)
    {
        energy += fuel * FuelRatio;
    }
}
