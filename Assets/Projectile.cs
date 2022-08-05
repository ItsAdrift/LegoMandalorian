using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject particleSystem;

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

            if (particleSystem != null)
            {
                ContactPoint contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 pos = contact.point;
                Destroy(Instantiate(particleSystem, pos, rot), 3f);
            }
            
            Destroy(gameObject);
        }
        
    }
}
