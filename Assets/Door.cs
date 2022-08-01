using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;
    public Transform exitPosition;

    public void Travel()
    {
        FindObjectOfType<Fade>().FadeInOut();
        player. = exitPosition.position;

    }
}
