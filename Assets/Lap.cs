using UnityEngine;

[System.Serializable]
public class Lap : ScriptableObject
{
    
    private int lap;
    private float startTime;
    private float endTime;

    public Lap(int lap)
    {
        this.lap = lap;
        name = "Lap " + lap;
    }

    public void StartLap()
    {
        startTime = Time.realtimeSinceStartup;
    }

    public void EndLap()
    {
        endTime = Time.realtimeSinceStartup;
    }

    public float GetStartTime()
    {
        return startTime;
    }

    
    // returns the time (in seconds) between the end and start of a lap
    public float GetTime()
    {
        return endTime - startTime;
    }
    
    public int GetLap()
    {
        return lap;
    }

}
