using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected int maxSpawnCount;
    [SerializeField] protected Transform parent;

    protected Platforms[] platformsSpawned;
    protected FloatingIslands[] islandsSpawned;
    protected CheckPoint checkPointSpawned;

    // this is the real platform spawner
    protected void IslandSpawner(FloatingIslands floatingIslands, CheckPoint checkPoints)
    {
        checkPointSpawned = Instantiate(checkPoints, parent);
        checkPointSpawned.Despawn();

        islandsSpawned = new FloatingIslands[maxSpawnCount];
        for (int spawnCount = 0; spawnCount < maxSpawnCount; spawnCount++)
        {
            islandsSpawned[spawnCount] = Instantiate(floatingIslands, parent);
            islandsSpawned[spawnCount].Despawn();
        }

    }

    // made a mistake with the name, was supposed to be root spawner but it does the job
    protected void PlatformSpawner(Platforms platforms)
    {
        platformsSpawned = new Platforms[maxSpawnCount];
        for (int spawnCount = 0; spawnCount < maxSpawnCount; spawnCount++)
        {
            platformsSpawned[spawnCount] = Instantiate(platforms, parent);
            platformsSpawned[spawnCount].Despawn();
        }
    }
}
