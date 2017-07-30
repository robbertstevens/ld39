using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private Fuel fuel;

    public GameObject Generator;

    private float lastTimeHealed = 0f;
    public float HealDelay = .1f;
    void Start() {
        fuel = Generator.GetComponent<Fuel>();
    }
    void OnTriggerStay2D(Collider2D collider) 
    {
        if (collider.gameObject.tag != Tag.Player) {
            return;
        }
        if (fuel.HealingActive) {
            if (lastTimeHealed > Time.time) {
                return;
            }
            collider.gameObject.GetComponent<PlayerController>().Energy += 1;  
            lastTimeHealed = Time.time + HealDelay;
        }
    }
}
