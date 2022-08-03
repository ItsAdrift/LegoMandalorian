using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{
    private List<Interactable> highlighted = new List<Interactable>();

    private void Start()
    {
        Interactable[] interactables = FindObjectsOfType<Interactable>();
        foreach (Interactable i in interactables)
        {
            i.OnHighlight.AddListener(Highlight);
            i.OnStopHighlight.AddListener(StopHighlight);
        }
    }

    private void Highlight(Interactable interactable)
    {
        highlighted.Add(interactable);
    }

    private void StopHighlight(Interactable interactable)
    {
        highlighted.Remove(interactable);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
