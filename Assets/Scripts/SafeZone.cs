using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public float velocityThreshold = 0.1f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Box box = other.gameObject.GetComponent(typeof(Box)) as Box;
        box.stalled = isVelocityValid(other.gameObject.GetComponent<Rigidbody2D>());
    }

    private bool isVelocityValid(Rigidbody2D rb)
    {
        return Math.Abs(rb.velocity.x) < velocityThreshold
            && Math.Abs(rb.velocity.y) < velocityThreshold; 
    }
}
