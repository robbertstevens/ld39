using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnergyToPlayer : MonoBehaviour
{
    private float Energy = 0;

    public int FuelRatio = 10;
    public float lastTimeHealed = 0f;
    public float healDelay = .5f;
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != Tag.Player)
        {
            return;
        }

        if (Energy <= 0) {
            return;
        }
        Debug.Log("healling");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (Time.time > lastTimeHealed+healDelay) {
            player.Energy += 1;
            Energy--;
            lastTimeHealed = Time.time;
        }
    }

    public void AddFuel(float fuel)
    {
        Energy += fuel * FuelRatio;
    }
}
