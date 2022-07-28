using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public bool isFirstPerson = false;
    public Camera activeCamera;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetActiveCamera(Camera camera, bool fps)
    {
        activeCamera = camera;
        isFirstPerson = fps;
    }
}
