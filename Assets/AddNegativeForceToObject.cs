using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNegativeForceToObject : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != Tag.Enemy)
        {
            return;
        }
		collision.collider.attachedRigidbody.AddForce(-(collision.collider.attachedRigidbody.velocity.normalized * 5));
    }
}
