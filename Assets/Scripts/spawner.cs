using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float timer = 0;
    private int boxSpawned = 0;

    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (boxSpawned < timer)
        {
            InstantiateBox();
        }
    }

    void InstantiateBox()
    {
        var position = new Vector3(this.transform.position.x, this.transform.position.y);
        Instantiate(box, position, Quaternion.identity);
        boxSpawned += 1;
    }
}
