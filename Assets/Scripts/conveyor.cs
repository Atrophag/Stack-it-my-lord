using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = new Vector3(0, 0, 0);
    private List<Rigidbody2D> onBelt = new List<Rigidbody2D>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Rigidbody2D rb in this.onBelt)
        {
            // TODO: do not update velocity if box is picked up
            rb.velocity = this.speed * this.direction;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.onBelt.Add(collision.rigidbody);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        this.onBelt.Remove(collision.rigidbody);
    }
}
