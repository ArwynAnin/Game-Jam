using UnityEngine;

public class Player : PlayerMovement
{
    #region Variables
    [Space]
    [Header("Platform Settings")]
    [SerializeField] private SpawnManager spawner;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private GameObject seed;
    [Space]
    [SerializeField] private float offset;
    [Space]
    [SerializeField] private float maxSize;
    [SerializeField] private float maxDistance;

    private Platforms plant;
    #endregion

    private void Update()
    {
        SpawnRoots();
    }

    #region Spawning Methods
    private void SpawnRoots()
    {
        spawning = Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) ? true : false;

        if (!spawning && plant != null)
        {
            plant.transform.parent = null;
            Rigidbody2D tempRb = plant.GetComponent<Rigidbody2D>();
            tempRb.bodyType = RigidbodyType2D.Dynamic;
        }

        SpawnMid();
        SpawnTop();
        SpawnBot();
    }

    private void SpawnTop()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) GetSeeds();

        if (!Input.GetKey(KeyCode.Alpha2) || plant == null) return;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = 45;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        size.y = 0.25f;
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance);
        position.y = Mathf.Clamp(position.y + offset / 2, 0, maxDistance);
        plant.transform.localPosition = position;
    }

    private void SpawnBot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3)) GetSeeds();

        if (!Input.GetKey(KeyCode.Alpha3) || plant == null) return;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = -45;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        size.y = 0.25f;
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance);
        position.y = Mathf.Clamp(position.y - offset / 2, -maxDistance, 0);
        plant.transform.localPosition = position;
    }

    private void SpawnMid()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) GetSeeds();

        if (!Input.GetKey(KeyCode.Alpha1) || plant == null) return;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = 0;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        size.y = 0.25f;
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance);
        plant.transform.localPosition = position;
    }

    private void GetSeeds()
    {
        plant = spawner.GetSeed();
        if (plant == null) return;
        plant.Spawn();
        plant.transform.position = spawnPoint.position;
        plant.transform.parent = spawnPoint;
        plant.transform.localScale = Vector2.one;
    }
    #endregion

}
