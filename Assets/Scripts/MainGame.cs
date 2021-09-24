using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public float textTimeSpan = 3f;

    private TimeSpan _timeSpan;
    private TextCountdown _textCountdown;
    private Spawner _spawner;

    void Start()
    {
        Debug.Log("MainGame START");

        _timeSpan = new TimeSpan(textTimeSpan);

        _spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        _textCountdown = GameObject.Find("Alert Text").GetComponent<TextCountdown>();

        _textCountdown.SetTextCountdown("Début du round dans ", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (_textCountdown.IsFinished())
        {
            _spawner.Activate();
        }
    }
}
