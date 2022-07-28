using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    [SerializeField] GameObject scope;
    [SerializeField] Camera scopeCamera;

    [SerializeField] Animator anim;


    public readonly int hash = Animator.StringToHash("Scope");

    // Update is called once per frame
    void Update()
    {
        scope.SetActive(Input.GetMouseButton(1));

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool(hash, true);
            //anim.Play("Scope");
            //anim.SetInteger(MinifigController.specialIdHash, 10);
            //anim.SetBool(MinifigController.playSpecialHash, true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool(hash, false);
        }

        if (Input.GetMouseButton(1))
        { 
            CameraManager.instance.SetActiveCamera(scopeCamera, true);
        }
            
        else
            CameraManager.instance.SetActiveCamera(Camera.main, false);

        if (Input.GetMouseButtonDown(0) && scope.active)
        {
            GetComponent<Gun>().Fire();
        }

    }
}
