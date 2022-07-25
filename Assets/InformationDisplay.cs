using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text speed;
    [SerializeField] Slider accelerator;
    [SerializeField] Slider brake;

    [SerializeField] CarController carController;

    public void LateUpdate()
    {
        speed.text = "" + (int)(carController.rigidbody.velocity.magnitude * 3.6);
        accelerator.value = carController.verticalInput;
        brake.value = Input.GetAxis("Brake");
    }
}
