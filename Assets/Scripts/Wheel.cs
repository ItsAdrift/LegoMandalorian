using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    /*public WheelCollider wheelCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Pothole")) {
            wheelCollider.suspensionDistance = 0f;

            Vector3 position = other.transform.position;
            position.y = transform.position.y;
            ParticleSystem p = Instantiate(roadPotholeParticles, position, Quaternion.identity);
            p.Play();
            Destroy(p.gameObject, 2f);
            soundEffect.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Pothole"))
        {
            wheelCollider.suspensionDistance = 0.3f;
        }
    }*/
}
