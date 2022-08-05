using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof (ObjectiveManager))]
public class ObjectiveDisplay : MonoBehaviour
{
    [SerializeField] GameObject objectiveDisplay;
    [SerializeField] TMP_Text objectiveText;

    ObjectiveManager manager;
    private void Start()
    {
        manager = GetComponent<ObjectiveManager>();
    }

    private void Update()
    {
        bool active = manager.activeObjectives.Count > 0;
        objectiveDisplay.SetActive(active);
        
        if (active)
            objectiveText.text = manager.activeObjectives[manager.activeObjectives.Count-1].description;
    }
}
