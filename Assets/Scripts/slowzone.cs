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
        (other.gameObject.GetComponent(typeof(Box)) as Box).setOnFire();
		// and slow it down
        slowBox(other.gameObject.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void slowBox(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2(0, maxVelocity);
        rigidbody.angularVelocity = 0;
        rigidbody.gravityScale = gravityScale;
    }
}
