using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent.GetComponent<LegoComponent>()?.Explode();
    }
}
