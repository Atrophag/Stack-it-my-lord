using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BoxSpritesEnum
{
    onFire = 1,
    stalled
}

public class Box : MonoBehaviour
{
    public float dragSpeed = 2f;
    public int extenguishFireCount = 5;
    public int onFireLevel = 0;
    // could be private
    public bool stalled = false;
    public bool pickedUp = false;

    private Vector3 _mouseOffset;

    public void setOnFire()
    {
        onFireLevel = extenguishFireCount;
    }

    void Update()
    {
        UpdateFireSprite();
        UpdateStalledSprite();
    }

    private void UpdateFireSprite()
    {
        float alpha = (float)onFireLevel / extenguishFireCount;
        Color color = new Color(1, 1, 1, alpha);
        GetSpriteRenderer(BoxSpritesEnum.onFire).color = color;
    }

    private void UpdateStalledSprite()
    {
        float alpha = stalled ? 1f : 0f;
        Color color = new Color(1, 1, 1, alpha);
        GetSpriteRenderer(BoxSpritesEnum.stalled).color = color;
    }

    private SpriteRenderer GetSpriteRenderer(BoxSpritesEnum index)
    {
        return transform.GetChild((int)index).gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        pickedUp = true;
        onFireLevel = onFireLevel > 0 ? onFireLevel - 1 : 0;
        // calc offset between mouse and gameObject
        _mouseOffset = GetGameObjectPosition() - GetMousePosition();
    }

    private void OnMouseUp()
    {
        pickedUp = false;
    }

    private void OnMouseDrag()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();

        var goalPos = GetMousePosition() + _mouseOffset;
        var objPos = GetGameObjectPosition();
        var vector = (goalPos - objPos) * dragSpeed;

        rigidbody.velocity = vector;
        rigidbody.angularVelocity = 0;
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
