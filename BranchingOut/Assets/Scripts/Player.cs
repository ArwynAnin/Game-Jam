using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : PlayerMovement
{
    #region Variables
    [Space]
    [Header("Platform Settings")]
    [SerializeField] private RootSpawner spawner;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private GameObject seed;
    [Space]
    [SerializeField] private float offset;
    [Space]
    [SerializeField] private float maxSize;
    [SerializeField] private float maxDistance;
    #endregion

    private void Update()
    {
        SpawnRoots();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Border")) return;
        StartCoroutine(PlayerDeath());
    }

    private IEnumerator PlayerDeath()
    {
        deathParticles.SetActive(true);
        isDead = false;
        player.velocity = Vector2.zero;
        player.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    #region Spawning Methods
    private void SpawnRoots()
    {
        spawning = (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3)) ? true : false;

        if (!spawning && plant != null) DropSeed();

        if ((Input.GetKeyDown(KeyCode.Alpha1) || 
            Input.GetKeyDown(KeyCode.Alpha2) || 
            Input.GetKeyDown(KeyCode.Alpha3)) && canSpawn) GetSeeds();

        if (Input.GetKey(KeyCode.Alpha1) && !Input.GetKey(KeyCode.Alpha2) && !Input.GetKey(KeyCode.Alpha3)) SpawnMid();
        else if (!Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha2) && !Input.GetKey(KeyCode.Alpha3)) SpawnTop();
        else if (!Input.GetKey(KeyCode.Alpha1) && !Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.Alpha3)) SpawnBot();
        else DropSeed();
    }

    private void DropSeed()
    {
        if (plant == null) return;
        Rigidbody2D tempRb = plant.GetComponent<Rigidbody2D>();
        tempRb.bodyType = RigidbodyType2D.Dynamic;
        plant.transform.parent = null;
        canSpawn = true;
        spawnParticles.SetActive(false);
    }

    private void SpawnTop()
    {
        if (plant == null) return;

        spawnParticles.SetActive(true);
        canSpawn = false;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = 45;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance - 1);
        position.y = Mathf.Clamp(position.y + offset / 2, 0, maxDistance - 1);
        plant.transform.localPosition = position;
    }

    private void SpawnBot()
    {
        if (plant == null) return;

        spawnParticles.SetActive(true);
        canSpawn = false;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = -45;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance - 1);
        position.y = Mathf.Clamp(position.y - offset / 2, -maxDistance + 1, 0);
        plant.transform.localPosition = position;
    }

    private void SpawnMid()
    {
        if (plant == null) return;

        spawnParticles.SetActive(true);
        canSpawn = false;

        Vector3 tilt = plant.transform.localEulerAngles;
        tilt.z = 0;
        plant.transform.localEulerAngles = tilt;

        // adjust size
        Vector2 size = plant.transform.localScale;
        size.x = Mathf.Clamp(size.x + offset, 0, maxSize);
        plant.transform.localScale = size;

        // adjust position
        Vector2 position = plant.transform.localPosition;
        position.x = Mathf.Clamp(position.x + offset / 2, 0, maxDistance);
        plant.transform.localPosition = position;
    }

    private IEnumerator Enlarge()
    {
        yield return null;
    }

    private void GetSeeds()
    {
        plant = spawner.GetSeed();
        if (plant == null) return;
        plant.Spawn();
        plant.transform.position = spawnPoint.position;
        plant.transform.localScale = Vector2.one;
    }
    #endregion

}
