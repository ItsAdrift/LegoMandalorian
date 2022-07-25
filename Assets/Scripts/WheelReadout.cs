using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelReadout : MonoBehaviour
{


    [Header("Text Components")]
    [SerializeField] private TMP_Text frontLeft;
    [SerializeField] private TMP_Text frontRight;
    [SerializeField] private TMP_Text rearLeft;
    [SerializeField] private TMP_Text rearRight;

    [Header("Wheel Components")]
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider rearLeftCollider;
    [SerializeField] private WheelCollider rearRightCollider;

    private void FixedUpdate()
    {

        WheelHit hit;
        frontLeftCollider.GetGroundHit(out hit);
        frontLeft.text = "FL " + (hit.sidewaysSlip / frontLeftCollider.sidewaysFriction.extremumSlip);
        if (hit.sidewaysSlip > 1 || hit.sidewaysSlip < -1)
            frontLeft.color = Color.red;
        else
            frontLeft.color = Color.white;

        frontRightCollider.GetGroundHit(out hit);
        frontRight.text = "FR " + (hit.sidewaysSlip / frontRightCollider.sidewaysFriction.extremumSlip);
        if (hit.sidewaysSlip > 1 || hit.sidewaysSlip < -1)
            frontRight.color = Color.red;
        else
            frontRight.color = Color.white;

        rearLeftCollider.GetGroundHit(out hit);
        rearLeft.text = "RL " + (hit.sidewaysSlip / rearLeftCollider.sidewaysFriction.extremumSlip);
        if (hit.sidewaysSlip > 1 || hit.sidewaysSlip < -1)
            rearLeft.color = Color.red;
        else
            rearLeft.color = Color.white;

        rearRightCollider.GetGroundHit(out hit);
        rearRight.text = "RR " + (hit.sidewaysSlip / rearRightCollider.sidewaysFriction.extremumSlip);
        if (hit.sidewaysSlip > 1 || hit.sidewaysSlip < -1)
            rearRight.color = Color.red;
        else
            rearRight.color = Color.white;
    }
}
