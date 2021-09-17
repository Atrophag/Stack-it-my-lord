using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Box box = other.gameObject.GetComponent(typeof(Box)) as Box;
        box.stalled = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Box box = other.gameObject.GetComponent(typeof(Box)) as Box;
        box.stalled = false;
    }
}
