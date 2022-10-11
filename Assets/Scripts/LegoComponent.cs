using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoComponent : MonoBehaviour
{
    [Header("Collision")]
    public bool collision = false;
    public bool rigidbody = false;

    [Header("Explosion")]
    public bool explodable = true;
    [Space]
    public float explosionForceMin = 100;
    public float explosionForceMax = 300;
    public float explosionRadius = 10;
    public float upwardForce = 1.5f;

    public float destroyDelay = 3f;

    public void Start()
    {
        Debug.Log("Check 1");
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("Check 2 - " + i);
            if (collision)
            {
                Debug.Log("Check 3");
                MeshCollider collider = transform.GetChild(i).gameObject.AddComponent<MeshCollider>();
                collider.convex = true;
            }
            if (rigidbody)
            {
                Debug.Log("Check 4");
                Rigidbody rb = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;
            }
            transform.GetChild(i).gameObject.AddComponent<LegoBrick>();
            Debug.Log("Check 5");

        }
        

        
    }

    public void Explode()
    {
        if (!explodable)
            return;
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
