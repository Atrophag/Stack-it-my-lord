using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // width in unit
    public float sceneWidth = 14;
    public float screenRatio = 0.5f;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = unitsPerPixel * Screen.height * screenRatio;

        _camera.orthographicSize = desiredHalfHeight;
    }
}
