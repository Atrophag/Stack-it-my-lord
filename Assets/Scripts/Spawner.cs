using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnerTimeSpan = 1.5f;
    // public for test purpose
    public bool active = false;
    public GameObject[] spawnables;

    private TimeSpan _timeSpan;

    void Start()
    {
        _timeSpan = new TimeSpan(spawnerTimeSpan);
        _timeSpan.active = false;
    }

    void Update()
    {
        if (_timeSpan.IsReady()) {
            InstantiateItem();
        }
    }

    void InstantiateItem()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        int index = Random.Range(0, spawnables.Length);
        
        GameObject clone = Instantiate(spawnables[index], position, Quaternion.identity);
        clone.tag = "Draggable";
        _timeSpan.UpdateTimer();
    }

    public void Activate()
    {
        _timeSpan.active = true;
    }

    public void Deactivate()
    {
        _timeSpan.active = false;
    }
}
