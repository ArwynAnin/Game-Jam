using System.Collections;
using UnityEngine;

public class IslandSpawner : SpawnManager
{
    [SerializeField] private FloatingIslands floatingIslands;
    [SerializeField] private CheckPoint checkPoints;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int checkPointLevel;

    Vector2 target;
    Vector2 lastSpawned;

    private void Awake()
    {
        IslandSpawner(floatingIslands, checkPoints);
    }

    private void Start()
    {

        lastSpawned = Vector2.zero;
        StartCoroutine(SpawnIslands());
    }

    private IEnumerator SpawnIslands()
    {
        // starts at 3 since there is already 2 spawned islands
        int current = 3;
        while (true)
        {
            if (current % checkPointLevel == 0) CheckPoint().Spawn();
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
        target = parent.position;
        target.y = Random.Range(2.5f, -3);

        islandsSpawned[current].transform.position = target;
        if (lastSpawned == Vector2.zero)
        {
            lastSpawned = target;
            return islandsSpawned[current];
        }

        target.x = lastSpawned.x + Random.Range(4.5f, 6.75f);
        islandsSpawned[current].transform.position = target;

        lastSpawned = target;
        return islandsSpawned[current];
    }

    private CheckPoint CheckPoint()
    {
        lastSpawned = target;
        if (checkPointSpawned.IsActive || checkPointSpawned == null) return null;
        target.x = lastSpawned.x + 8;
        lastSpawned.x += 8;
        checkPointSpawned.transform.position = lastSpawned;

        return checkPointSpawned;
    }
}
