using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] public FinishLine finishLine;
    [ReadOnly] public List<Lap> laps = new List<Lap>();
    [ReadOnly] public Lap lastLap;
    [ReadOnly] public Lap currentLap;
    [ReadOnly] public Lap bestLap = null;

    public void Start()
    {
        FinishLine.OnFinishLineCross.AddListener(OnFinishLap);
    }

    public void OnFinishLap()
    {
        // Starting the first lap
        if (currentLap == null)
        {
            currentLap = new Lap(1);
            currentLap.StartLap();
            return;
        }

        currentLap.EndLap();
        lastLap = currentLap;
        laps.Add(lastLap);

        
        if (bestLap == null) {
            bestLap = lastLap; 
        } else if (lastLap.GetTime() < bestLap.GetTime())
        {
            bestLap = lastLap;
        }

        currentLap = new Lap(lastLap.GetLap()+1);
        currentLap.StartLap();
    }

}
