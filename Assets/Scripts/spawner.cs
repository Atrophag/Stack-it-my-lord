using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timerOffset = 1.0f;
    public float timerSpan = 1.0f;
    public bool active = true;

    // gameObject linked on spawner scene
    public GameObject box;

    // private float timer;
    private float lastInstatiatedBoxTimer;

    // Start is called before the first frame update
    void Start()
    {
        lastInstatiatedBoxTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            var timer = Time.fixedTime;
            if (timer > timerOffset && timer > lastInstatiatedBoxTimer + timerSpan)
            {
                InstantiateBox();
            }
        }
    }

    void InstantiateBox()
    {
        var position = new Vector3(transform.position.x, transform.position.y);
        Instantiate(box, position, Quaternion.identity);
        lastInstatiatedBoxTimer = Time.fixedTime;
    }
}
