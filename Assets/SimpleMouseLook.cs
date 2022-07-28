using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseLook : MonoBehaviour
{

    public float sensitivity = 100f;
    public Transform player;

    float xRotation = 0f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, 180);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (player)
            player.Rotate(Vector3.up * mouseX);
    }

}
