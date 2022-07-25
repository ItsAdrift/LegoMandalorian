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

    public void Explode() {
        for (int i = 0; i < transform.childCount; i++) {
            MeshCollider collider = transform.GetChild(i).gameObject.AddComponent<MeshCollider>();
            collider.convex = true;
            Rigidbody rb = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            rb.AddExplosionForce(Random.Range(explosionForceMin, explosionForceMax), transform.position, explosionRadius, upwardForce);
            Destroy(transform.GetChild(i).gameObject, destroyDelay);
        }
        Destroy(gameObject, destroyDelay + 1f);
    } 
}
