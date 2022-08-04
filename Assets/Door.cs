using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MinifigController player;
    public Transform exitPosition;

    public void Travel()
    {
        FindObjectOfType<Fade>().FadeInOut();

        player.TeleportTo(exitPosition.position);
        player.transform.rotation = exitPosition.rotation;
        

    }
}
