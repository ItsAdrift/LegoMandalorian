using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minifig : MonoBehaviour
{
    [Header("Head")]
    [SerializeField] private Transform headAttatchment;
    [SerializeField] GameObject[] headAttatchments;

    public void Awake()
    {
        foreach (GameObject obj in headAttatchments)
        {
            obj.transform.SetParent(headAttatchment);
        }
    }
}
