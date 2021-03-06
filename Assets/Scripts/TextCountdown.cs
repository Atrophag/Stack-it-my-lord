using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

class TextCountdown : MonoBehaviour
{
    public float textTimeSpan = 1f; // 1sec

    private TimeSpan _timeSpan;
    private TextMeshProUGUI _textMesh;

    private string _text;
    private uint _count;
    private bool _displayCounter;

    void Start()
    {
        _textMesh = GameObject.Find("Alert Text").GetComponent<TextMeshProUGUI>();
        _timeSpan = new TimeSpan(textTimeSpan);
        _timeSpan.active = false;
    }

    void Update()
    {
        if (_timeSpan.IsReady())
        {
            if (_count > 0)
            {
               SetText(_text + (_displayCounter ? _count.ToString() : ""));
            }
            else
            {
                _textMesh.SetText("");
                _timeSpan.active = false;
            }
            _count -= 1;
        }
    }
    
    // launch func
    public void Set(string text, uint count, bool displayCounter = true)
    {
        _text = text;
        _count = count;
        _timeSpan.active = true;
        _displayCounter = displayCounter;
    }

    public void SetText(string text)
    {
        _textMesh.SetText(text);
        _timeSpan.UpdateTimer();
    }

    public bool IsFinished()
    {
        return !_timeSpan.active;
    }
}