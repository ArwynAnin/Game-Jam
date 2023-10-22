using UnityEngine;

public class IslandSpawner : SpawnManager
{
    [SerializeField] private GameObject floatingIslands;
    [SerializeField] private GameObject checkPoints;

    private void Awake()
    {
        IslandSpawner(floatingIslands, checkPoints);
    }
}
