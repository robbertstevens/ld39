using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnergyToPlayer : MonoBehaviour
{
    private float energy = 0;

    public int FuelRatio = 10;
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Healing Player");
        if (collision.gameObject.tag != Tag.Player)
        {
            return;
        }
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        StartCoroutine(HealPlayer(player));
    }

    private IEnumerator HealPlayer(PlayerController player)
    {
        while(energy > 0) {
            player.Energy += energy--;
            yield return new WaitForSecondsRealtime(.1f);   
        }
    }

    public void AddFuel(float fuel)
    {
        energy += fuel * FuelRatio;
    }
}
