using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    public Camera camera;

    public void Fire()
    {
        Debug.Log("Firing");
        GameObject projectile = Instantiate(laserPrefab) as GameObject;
        projectile.transform.position = transform.position + camera.transform.forward * 2;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = camera.transform.forward * 40;
    }
}
