using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationZone : MonoBehaviour
{
    public float velocityThreshold = 0.1f;

    private void OnTriggerStay2D(Collider2D other)
    {
        DraggableItem item = Utils.CastDraggableItem(other.gameObject);
        bool stalled = isVelocityValid(Utils.CastRigidBody(other.gameObject));
        item.stalled = stalled;
    }
    private bool isVelocityValid(Rigidbody2D rb)
    {
        return Math.Abs(rb.velocity.x) < velocityThreshold
            && Math.Abs(rb.velocity.y) < velocityThreshold; 
    }
}
