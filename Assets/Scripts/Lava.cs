using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
		// set box on fire
        Utils.CastDraggableItem(other.gameObject).setOnFire();
    }
}