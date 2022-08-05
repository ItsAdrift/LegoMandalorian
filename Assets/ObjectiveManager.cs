using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] public List<Objective> objectives = new List<Objective>();
    private Dictionary<string, Objective> objectiveMap = new Dictionary<string, Objective>();

    public List<Objective> activeObjectives = new List<Objective>();

    public UnityEvent<Objective> OnObjectiveCompleted;

    private void Awake()
    {
        foreach (Objective objective in objectives)
            objectiveMap.Add(objective.id, objective);

        if (OnObjectiveCompleted == null)
            OnObjectiveCompleted = new UnityEvent<Objective>();
    }

    public void AddActiveObjective(string objective)
    {
        AddActiveObjective(objectiveMap.GetValueOrDefault(objective));
    }

    public void CompleteObjective(string objective)
    {
        CompleteObjective(objectiveMap.GetValueOrDefault(objective));
    }

    public void AddActiveObjective(Objective objective)
    {
        activeObjectives.Add(objective);
    } 

    public void CompleteObjective(Objective objective)
    {
        activeObjectives.Remove(objective);
        OnObjectiveCompleted.Invoke(objective);
    }

}
