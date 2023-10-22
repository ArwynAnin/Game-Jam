using System.Collections;
using UnityEngine;

public class IslandSpawner : SpawnManager
{
    [SerializeField] private FloatingIslands floatingIslands;
    [SerializeField] private CheckPoint checkPoints;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int checkPointLevel;

    private void Awake()
    {
        IslandSpawner(floatingIslands, checkPoints);
    }

    private void Start()
    {
        StartCoroutine("SpawnIslands");
    }

    private IEnumerator SpawnIslands()
    {
        // starts at 3 since there is already 2 spawned islands
        int current = 3;
        while (true)
        {
            if (current % 10 == 0) CheckPoint().Spawn();
            else GetIsland().Spawn();

            yield return new WaitForSeconds(spawnDelay);
            current++;
        }
    }

    private FloatingIslands GetIsland()
    {
        for (int current = 0; current < islandsSpawned.Length; current++)
        {
            if (!islandsSpawned[current].IsActive && islandsSpawned[current] != null) return SetPosition(current);
        }
        return null;
    }

    private FloatingIslands SetPosition(int current)
    {
        Vector2 target = parent.position;
        target.y = Random.Range(2.5f, -3);
        islandsSpawned[current].transform.position = target;
        return islandsSpawned[current];
    }

    private CheckPoint CheckPoint()
    {
        if (checkPointSpawned.IsActive || checkPointSpawned == null) return null;
        checkPointSpawned.transform.position = parent.position; 
        return checkPointSpawned;
    }
}
