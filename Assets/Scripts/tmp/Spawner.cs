using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timerOffset = 1.0f;
    public float timerSpan = 1.0f;
    public bool active = true;

    // gameObject linked on spawner scene
    public GameObject Box;

    // private float timer;
    private float _lastInstatiatedBoxTimer;

    // Start is called before the first frame update
    void Start()
    {
        _lastInstatiatedBoxTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            var timer = Time.fixedTime;
            if (timer > timerOffset && timer > _lastInstatiatedBoxTimer + timerSpan)
            {
                InstantiateBox();
            }
        }
    }

    void InstantiateBox()
    {
        var position = new Vector3(transform.position.x, transform.position.y);
        Instantiate(Box, position, Quaternion.identity);
        _lastInstatiatedBoxTimer = Time.fixedTime;
    }
}
