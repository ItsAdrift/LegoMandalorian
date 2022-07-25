using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] public bool isController = true;
    [SerializeField] Camera[] cameras;
    private int cameraIndex = 0;
    [Space]
    [Header("Settings")]
    [Space]
    [Header("Friction")]
    float desiredFriction = 1.5f;
    public float surfaceFriction = 1.5f;
    public float driftFriction = 0.75f;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    [HideInInspector] public float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;

    [ReadOnly] private bool isBreaking;
    [ReadOnly] private bool isAccelerating;
    [ReadOnly] private bool isReversing = false;

    enum Gear { REVERSE, DRIVE };
    [SerializeField] [ReadOnly] Gear gear = Gear.DRIVE;

    [Header("Forces")]
    [SerializeField] private float motorForce;
    [SerializeField] private float motorForceMultiplier;
    [SerializeField] private float breakForce;
    [SerializeField] private float reverseForce;

    [Header("Steering")]
    [SerializeField] private float defaultSteeringAngle = 30f;
    [SerializeField] private float steeringAngleSpeedMultiplier = 0.2f;
    [SerializeField] [ReadOnly] float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [HideInInspector] public Rigidbody rigidbody;


    public float mass = -0.9f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = new Vector3(0f, mass, 0f);
        maxSteerAngle = defaultSteeringAngle;
    }

    private void Update()
    {
        if (Input.GetButtonDown("ChangeCamera"))
        {
            Debug.Log("Changing Cameras");
            cameraIndex++;
            if (cameraIndex >= cameras.Length)
                cameraIndex = 0;

            foreach (Camera cam in cameras)
            {
                cam.enabled = false;
            }

            cameras[cameraIndex].enabled = true;
            

        }
    }

    private void FixedUpdate()
    {
        float speed = rigidbody.velocity.magnitude;
        maxSteerAngle = defaultSteeringAngle - (speed * steeringAngleSpeedMultiplier);
        maxSteerAngle = Mathf.Clamp(maxSteerAngle, 0, defaultSteeringAngle);

        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space) || (Input.GetAxis("Brake") >= 0.5f);
        if (isController)
        {
            isAccelerating = (Input.GetAxis("Accelerate") >= 0.5f);
            verticalInput = Input.GetAxis("Accelerate");
        }

        if (isAccelerating)
            isReversing = false;


    }

    private void HandleMotor()
    {
        // Handle friction
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Drift"))
            desiredFriction = driftFriction;
        else
            desiredFriction = surfaceFriction;
                
        WheelFrictionCurve friction = rearLeftWheelCollider.sidewaysFriction;
        friction.stiffness = desiredFriction;
        rearLeftWheelCollider.sidewaysFriction = friction;
        rearRightWheelCollider.sidewaysFriction = friction;

        // Handle Reverse/Drive

        if (isController)
        {
            /*if (isReversing || (!isAccelerating && isBreaking))
            {
                // is reversing
                frontLeftWheelCollider.motorTorque = -reverseForce * motorForceMultiplier;
                frontRightWheelCollider.motorTorque = -reverseForce * motorForceMultiplier;
                isReversing = true;
                return;
            }*/
        }

        frontLeftWheelCollider.motorTorque = verticalInput * (motorForce * motorForceMultiplier);
        frontRightWheelCollider.motorTorque = verticalInput * (motorForce * motorForceMultiplier);

        if (!isAccelerating)
        {
            frontLeftWheelCollider.motorTorque -= (motorForce * Time.deltaTime);
            frontRightWheelCollider.motorTorque -= (motorForce * Time.deltaTime);
        }

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        if (isReversing)
            return;
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform, true);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform, true);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform, false);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform, false);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, bool isFront)
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        Vector3 r = rot.eulerAngles;

         r.z = -r.x;
         r.x = 0;


         wheelTransform.eulerAngles = r;
         Vector3 v = wheelTransform.localEulerAngles;
         if (isFront)
         {

             v.y = currentSteerAngle;

         } else
         {
             v.y = 0;
         }
         //wheelTransform.localEulerAngles = v;
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}