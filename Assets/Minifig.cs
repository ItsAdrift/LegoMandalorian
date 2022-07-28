using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minifig : MonoBehaviour
{
    [Header("Head")]
    [SerializeField] private Transform headAttatchment;
    [SerializeField] GameObject[] headAttatchments;

    [Header("Right Hand")]
    [SerializeField] private Transform rightHandAttatchment;
    [SerializeField] GameObject[] rightHandAttatchments;

    [Header("Left Hand")]
    [SerializeField] private Transform leftHandAttatchment;
    [SerializeField] GameObject[] leftHandAttatchments;

    public void Awake()
    {
        foreach (GameObject obj in headAttatchments)
        {
            obj.transform.SetParent(headAttatchment);
        }

        foreach (GameObject obj in rightHandAttatchments)
        {
            obj.transform.SetParent(rightHandAttatchment);
        }

        foreach (GameObject obj in leftHandAttatchments)
        {
            obj.transform.SetParent(leftHandAttatchment);
        }
    }
}
