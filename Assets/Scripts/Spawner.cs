using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timerOffset = 1.0f;
    public float timerSpan = 1.0f;
    public bool active = true;
    public GameObject[] spawnables;

    private float _lastInstatiatedBoxTimer;

    void Start()
    {
        _lastInstatiatedBoxTimer = 0;
    }

    void Update()
    {
        if (active) {
            var timer = Time.fixedTime;
            if (timer > timerOffset && timer > _lastInstatiatedBoxTimer + timerSpan)
            {
                InstantiateItem();
            }
        }
    }

    void InstantiateItem()
    {
        var position = new Vector3(transform.position.x, transform.position.y);
        var index = Random.Range(0, spawnables.Length);
        
        Instantiate(spawnables[index], position, Quaternion.identity);
        _lastInstatiatedBoxTimer = Time.fixedTime;
    }
}
