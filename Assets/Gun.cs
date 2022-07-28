using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float velocity = 80;

    [SerializeField] GameObject laserPrefab;
    public Camera camera;

    public void Fire()
    {
        GameObject projectile = Instantiate(laserPrefab) as GameObject;
        projectile.transform.position = transform.position + camera.transform.forward * 2;
        projectile.transform.eulerAngles = camera.gameObject.transform.eulerAngles;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = camera.transform.forward * velocity;
    }
}
