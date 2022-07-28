using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.transform.parent != null)
        {
            if (collision.transform.parent.GetComponent<LegoComponent>() != null)
                collision.transform.parent.GetComponent<LegoComponent>()?.Explode();
            Destroy(gameObject);
        }
        
    }
}
