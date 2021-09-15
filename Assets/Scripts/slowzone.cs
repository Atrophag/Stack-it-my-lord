using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowzone : MonoBehaviour
{
    public float maxVelocity = -2.0f;
    public float gravityScale = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        slowBox(collider.gameObject.GetComponent<Rigidbody2D>());
    }

    void slowBox(Rigidbody2D box)
    {
        box.velocity = new Vector2(0, maxVelocity);
        box.angularVelocity /= 4;
        box.gravityScale = gravityScale;
    }
}
