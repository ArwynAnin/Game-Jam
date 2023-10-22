using UnityEngine;

public class RootSpawner : SpawnManager
{
    [SerializeField] Platforms roots;

    private void Awake()
    {
        PlatformSpawner(roots);
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
