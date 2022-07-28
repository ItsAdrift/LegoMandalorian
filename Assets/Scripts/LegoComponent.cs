using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoComponent : MonoBehaviour
{
    public float explosionForceMin = 100;
    public float explosionForceMax = 300;
    public float explosionRadius = 10;
    public float upwardForce = 1.5f;

    public float destroyDelay = 3f;

    [Header("Collision")]
    public bool collision = false;
    public bool rigidbody = false;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (collision)
            {
                MeshCollider collider = transform.GetChild(i).gameObject.AddComponent<MeshCollider>();
                collider.convex = true;
            }
            if (rigidbody)
            {
                Rigidbody rb = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;
            }
            transform.GetChild(i).gameObject.AddComponent<LegoBrick>();
                
        }
        

        
    }

    public void Explode()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;

            LegoBrick lb = obj.gameObject.GetComponent<LegoBrick>();
            if (lb.exploded)
                return;
            else
                lb.exploded = true;

            Rigidbody rb = obj.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            if (rb != null)
                rb.AddExplosionForce(Random.Range(explosionForceMin, explosionForceMax), transform.position, explosionRadius, upwardForce);
            Destroy(obj, destroyDelay);
        }
        Destroy(gameObject, destroyDelay + 1f);

    }



}
