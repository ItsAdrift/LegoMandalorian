using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheelModifier : MonoBehaviour
{
    [SerializeField] CarController carController;
    [SerializeField] WheelCollider[] wheels;

    [SerializeField] float gradient = -0.025f;
    [SerializeField] float yIntercept = 2;
    [ReadOnly][SerializeField] float speed;
    [ReadOnly][SerializeField] float stiffness;

    private void FixedUpdate()
    {
        speed = carController.rigidbody.velocity.magnitude;
        stiffness = (gradient * speed) + yIntercept;
        foreach(WheelCollider c in wheels)
        {
            WheelFrictionCurve curve = c.sidewaysFriction;
            curve.stiffness = stiffness;
            c.sidewaysFriction = curve;
        }
    }
}
