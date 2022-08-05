using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Objective", menuName = "Create Objective")]
public class Objective : ScriptableObject
{
    public string id = "newObjective";
    public bool completed = false;

    public string description;
}
