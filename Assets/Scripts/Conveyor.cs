using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = new Vector3(-1, 0, 0);
    private List<GameObject> _onBelt = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gameObject in this._onBelt)
        {
            if (!Utils.CastDraggableItem(gameObject).pickedUp) {
                Utils.CastRigidBody(gameObject).velocity = this.speed * this.direction;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this._onBelt.Add(other.gameObject);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        this._onBelt.Remove(other.gameObject);
    }
}
