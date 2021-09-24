using UnityEngine;

class TimeSpan
{
    public bool active = true;
    
    private float _timespan;
    private float _lastTime = 0;

    // constructor
    public TimeSpan(float timespan)
    {
        _timespan = timespan;
    }

    public void UpdateTimer()
    {
        _lastTime = Time.fixedTime;
    }

    public bool IsReady()
    {
        if (active)
        {
            float timer = Time.fixedTime;
            return (_lastTime + _timespan) < timer;
        }

        return false;
    }
}