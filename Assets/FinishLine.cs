using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public static UnityEvent OnFinishLineCross;

    void Awake()
    {
        if (OnFinishLineCross == null)
            OnFinishLineCross = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            OnFinishLineCross.Invoke();
    }
}
