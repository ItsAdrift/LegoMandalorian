using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapDisplay : MonoBehaviour
{
    [SerializeField] Track track;
    [SerializeField] TMP_Text currentLap;
    [SerializeField] TMP_Text bestLap;
    [SerializeField] Transform lapHolder;
    [SerializeField] GameObject lapPrefab;

    [SerializeField] float addLapDelay = 0.1f;
    [SerializeField] int maxLaps = 5;

    private void Start()
    {
        FinishLine.OnFinishLineCross.AddListener(AddNewLap);
    }

    public void AddNewLap()
    {
        StartCoroutine(_AddNewLap(addLapDelay));
    }

    public IEnumerator _AddNewLap(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (track.lastLap == null || track.lastLap.GetLap() == 0)
            yield break;

        bestLap.text = "Best: " + (System.Math.Round(track.bestLap.GetTime(), 3).ToString("0.000"));

        GameObject obj = Instantiate(lapPrefab, lapHolder);
        TMP_Text text = obj.GetComponent<TMP_Text>();
        string textValue = track.lastLap.GetLap() + ". " + (System.Math.Round(track.lastLap.GetTime(), 3).ToString("0.000"));
        text.text = "";

        if (lapHolder.childCount > maxLaps)
        {
            Destroy(lapHolder.GetChild(0).gameObject);
        }

        // Small Flash Animation

        yield return new WaitForSeconds(0.5f - addLapDelay);
        
        text.text = textValue;

        yield return new WaitForSeconds(0.5f);

        text.text = "";

        yield return new WaitForSeconds(0.5f);

        text.text = textValue;

    }

    private void Update()
    {
        if (track.currentLap != null)
            currentLap.text = System.Math.Round(Time.realtimeSinceStartup - track.currentLap.GetStartTime(), 1).ToString("0.0");
    }

}
