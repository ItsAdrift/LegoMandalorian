using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public bool displayed = false;
    [SerializeField] GameObject display;

    private void Start()
    {
        display.SetActive(displayed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            displayed = !displayed;
            display.SetActive(displayed);
        }
    }
}
