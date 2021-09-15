using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int speed = 2;
    public bool pickedUp = false;
    private Vector3 mouseOffset;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector3 GetGameObjectPosition()
    {
        return gameObject.transform.position;
    }

    void OnMouseDown()
    {
        pickedUp = true;
        // calc offset between mouse and gameObject
        mouseOffset = GetGameObjectPosition() - GetMousePosition();
    }

    void OnMouseUp()
    {
        pickedUp = false;
    }

    void OnMouseDrag()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();

        var goalPos = GetMousePosition() + mouseOffset;
        var objPos = GetGameObjectPosition();
        var vector = (goalPos - objPos) * speed;

        rigidbody.velocity = vector;
    }

}
