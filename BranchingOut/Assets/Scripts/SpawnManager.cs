using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Space]
    [Header("Spawn Settings")]
    [SerializeField] private Platforms platforms;
    [Space]
    [SerializeField] protected int maxSpawnCount;

    private Platforms[] platformsSpawned;

    private void Awake()
    {
        platformsSpawned = new Platforms[maxSpawnCount];
        for (int spawnCount = 0; spawnCount < maxSpawnCount; spawnCount++)
        {
            platformsSpawned[spawnCount] = Instantiate(platforms, this.transform);
            platformsSpawned[spawnCount].Despawn();
        }
    }

    public Platforms GetSeed()
    {
        for (int current = 0; current < platformsSpawned.Length; current++)
        {
            if (!platformsSpawned[current].IsActive && platformsSpawned[current] != null) return platformsSpawned[current];
        }
        return null;
    }
}
