using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpriteMasksEnum
{
    pickedUp = 1,
    onFire,
}

public class DraggableItem : MonoBehaviour
{
    public float dragSpeed = 2f;
    public int extenguishFireCount = 5;
    public int onFireLevel = 0;
    public bool stalled = false;
    public bool pickedUp = false;
    public int score = 10;

    private Vector3 _mouseOffset;
    private bool _active = true;

    public void setOnFire()
    {
        onFireLevel = extenguishFireCount;
    }

    void Update()
    {
        UpdateMask(SpriteMasksEnum.pickedUp, Convert.ToSingle(pickedUp));
        UpdateMask(SpriteMasksEnum.onFire, (float)onFireLevel / (float)extenguishFireCount);
    }

    public void Deactivate()
    {
        _active = false;
        pickedUp = false;
    }

    private void UpdateMask(SpriteMasksEnum maskIndex, float alpha)
    {
        Color color = new Color(1, 1, 1, alpha);
        GetSpriteRenderer(maskIndex).color = color;
    }

    private SpriteRenderer GetSpriteRenderer(SpriteMasksEnum index)
    {
        return transform.GetChild((int)index).gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (_active)
        {
            pickedUp = true;
            onFireLevel = onFireLevel > 0 ? onFireLevel - 1 : 0;
            // calc offset between mouse and gameObject
            _mouseOffset = GetGameObjectPosition() - GetMousePosition();
        }
    }

    private void OnMouseUp()
    {
        pickedUp = false;
    }

    private void OnMouseDrag()
    {
        if (_active)
        {
            var rigidbody = Utils.CastRigidBody(gameObject);

            var goalPos = GetMousePosition() + _mouseOffset;
            var objPos = GetGameObjectPosition();
            var vector = (goalPos - objPos) * dragSpeed;

            rigidbody.velocity = vector;
            rigidbody.angularVelocity = 0;
        }
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
