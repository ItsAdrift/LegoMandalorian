using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public UnityEvent<Interactable> OnInteract;
    public UnityEvent<Interactable> OnHighlight;
    public UnityEvent<Interactable> OnStopHighlight;

    [SerializeField] Vector3 offset;
    [SerializeField] float radius = 5;

    public abstract void Interact();

    public abstract void Highlight();

    public abstract void StopHighlight();

    private void Awake()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.center = offset;
        collider.radius = radius;
        collider.isTrigger = true;

        if (OnInteract == null)
            OnInteract = new UnityEvent<Interactable>();
        if (OnHighlight == null)
            OnHighlight = new UnityEvent<Interactable>();
        if (OnStopHighlight == null)
            OnStopHighlight = new UnityEvent<Interactable>();
    }
        

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (offset * transform.localScale.x), radius * transform.localScale.x);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Highlight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopHighlight();
        }
    }
}
