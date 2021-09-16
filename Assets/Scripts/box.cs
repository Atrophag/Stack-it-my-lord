using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float dragSpeed = 2f;
    public int onFireLevel = 0;
    public int extenguishFireCount = 5;
    public bool isPickedUp = false;
    private Vector3 mouseOffset;

    void Update()
    {
        float alpha = (float)onFireLevel / extenguishFireCount;
        Color color = new Color(1, 1, 1, alpha);
        // TODO: GetChild(1)
        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    public void setOnFire()
    {
        onFireLevel = extenguishFireCount;
    }

    void OnMouseDown()
    {
        isPickedUp = true;
        onFireLevel = onFireLevel > 0 ? onFireLevel - 1 : 0;
        // calc offset between mouse and gameObject
        mouseOffset = GetGameObjectPosition() - GetMousePosition();
    }

    void OnMouseUp()
    {
        isPickedUp = false;
    }

    void OnMouseDrag()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();

        var goalPos = GetMousePosition() + mouseOffset;
        var objPos = GetGameObjectPosition();
        var vector = (goalPos - objPos) * dragSpeed;

        rigidbody.velocity = vector;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector3 GetGameObjectPosition()
    {
        return gameObject.transform.position;
    }

}
