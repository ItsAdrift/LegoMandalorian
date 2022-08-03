using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandardInteractable : Interactable
{

    public override void Highlight()
    {
        OnHighlight.Invoke(this);
    }

    public override void Interact()
    {
        OnInteract.Invoke(this);
    }

    public override void StopHighlight()
    {
        OnStopHighlight.Invoke(this);
    }
}
