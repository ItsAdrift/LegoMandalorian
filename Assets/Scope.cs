using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    [SerializeField] GameObject scope;
    [SerializeField] Camera scopeCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CameraManager.instance.SetActiveCamera(scopeCamera, true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            CameraManager.instance.SetActiveCamera(Camera.main, false);
            
        }
        scope.SetActive(Input.GetMouseButton(1));
        scopeCamera.gameObject.SetActive(Input.GetMouseButton(1));

        if (Input.GetMouseButtonDown(0) && scope.active)
        {
            GetComponent<Gun>().Fire();
        }
    }
}
