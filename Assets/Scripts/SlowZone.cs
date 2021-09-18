using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float maxVelocity = -2.0f;
    public float gravityScale = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
		// set box on fire
        Utils.CastDraggableItem(other.gameObject).setOnFire();
		// and slow it down
        slowBox(Utils.CastRigidBody(other.gameObject));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Utils.CastRigidBody(other.gameObject).gravityScale = 1;
    }

    void slowBox(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2(0, maxVelocity);
        rigidbody.angularVelocity = 0;
        rigidbody.gravityScale = gravityScale;
    }
}
