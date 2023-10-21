using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected int maxSpawnCount;

    protected Platforms[] platformsSpawned;
    private GameObject[] islandsSpawned;

    // this is the real platform spawner
    protected void IslandSpawner(GameObject floatingIslands, GameObject checkPoints)
    {
        int x = 18;
        islandsSpawned = new GameObject[maxSpawnCount];
        for (int spawnCount = 3; spawnCount < maxSpawnCount; spawnCount++)
        {
            float y = Random.Range(-4.75f, 2.15f);
            islandsSpawned[spawnCount] = spawnCount%5 == 0 ? Instantiate(checkPoints, this.transform) : Instantiate(floatingIslands, this.transform);
            islandsSpawned[spawnCount].transform.position = new Vector2(x,y);

            x += 12;
        }

    }

    // made a mistake with the name, was supposed to be root spawner but it does the job
    protected void PlatformSpawner(Platforms platforms)
    {
        platformsSpawned = new Platforms[maxSpawnCount];
        for (int spawnCount = 0; spawnCount < maxSpawnCount; spawnCount++)
        {
            platformsSpawned[spawnCount] = Instantiate(platforms, this.transform);
            platformsSpawned[spawnCount].Despawn();
        }
    }
}
