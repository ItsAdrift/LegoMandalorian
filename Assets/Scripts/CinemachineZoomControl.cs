using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineZoomControl : MonoBehaviour
{
    public float sensitivity = 5f;
    public float smoothing = 2f;

    public float minFOV = 30;
    public float maxFOV = 90;

    CinemachineFreeLook cam;
    float defaultFOV = 60;

    float targetFOV = 60;

    private void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        defaultFOV = cam.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            targetFOV = defaultFOV;
        } else
        {
            targetFOV = Mathf.Clamp(targetFOV - (Input.mouseScrollDelta.y * sensitivity), minFOV, maxFOV);
        }

        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, targetFOV, smoothing * Time.deltaTime);
    }
}
