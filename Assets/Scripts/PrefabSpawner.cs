using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void Spawn()
    {
        spawnedObjects.Add(Instantiate(prefab, transform));
    }

    public void Explode()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            obj.GetComponent<LegoComponent>()?.Explode();
        }
        spawnedObjects.Clear();
    }
}
