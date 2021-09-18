using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidZone : MonoBehaviour
{
    public float velocityThreshold = 0.1f;
    private List<DraggableItem> _list = new List<DraggableItem>();
    private GameScore GameScore = new GameScore();

    private void Start()
    {
        GameScore.Initialize();
    }

    private void Update()
    {
        int count = 0;
        foreach (DraggableItem item in _list)
        {
            count += item.stalled ? item.score : 0;
        }
        GameScore.SetScore(count);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        DraggableItem item = Utils.CastDraggableItem(other.gameObject);
        bool stalled = isVelocityValid(Utils.CastRigidBody(other.gameObject));
        item.stalled = stalled;
    }
    private bool isVelocityValid(Rigidbody2D rb)
    {
        return Math.Abs(rb.velocity.x) < velocityThreshold
            && Math.Abs(rb.velocity.y) < velocityThreshold; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _list.Add(Utils.CastDraggableItem(other.gameObject));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _list.Remove(Utils.CastDraggableItem(other.gameObject));
    }
}
