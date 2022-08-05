using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tag = "Player";
    public UnityEvent TriggerEnterEvent;
    
    public void Start()
    {
        if (TriggerEnterEvent == null)
            TriggerEnterEvent = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag)
            TriggerEnterEvent.Invoke();
    }
}
