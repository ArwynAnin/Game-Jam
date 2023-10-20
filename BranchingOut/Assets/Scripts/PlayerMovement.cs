using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Space]
    [Header ("Player Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [Space]
    [SerializeField] private LayerMask layer;

    [Space]
    [Header ("Platform Settings")]
    [SerializeField] private SpawnManager spawner;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private GameObject seed;
    [Space]
    [SerializeField] private float maxSize;
    [SerializeField] private float maxDistance;


    private CapsuleCollider2D collider;
    private Rigidbody2D player;
    private Platforms plant;

    private bool spawning;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        spawning = false;
    }

    private void Update()
    {
        SpawnRoots();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        VerticalMovement(IsGrounded());
    }
    #endregion

    #region Spawning Methods
    private void SpawnRoots()
    {
        spawning = Input.GetKey(KeyCode.Q) ? true : false;

        float offset = 0.1f;

        if (!spawning && plant != null)
        {
            plant.transform.parent = null;
            Rigidbody2D tempRb = plant.GetComponent<Rigidbody2D>();
            tempRb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (Input.GetKeyDown(KeyCode.Q)) GetSeeds();

        if (!Input.GetKey(KeyCode.Q) || plant == null) return;

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

    #region Movements
    private void HorizontalMovement()
    {
        if (spawning || !IsGrounded()) return;

        // set horizontal motion so to not affect vertical motion
        Vector2 motion = player.velocity;
        motion.x = Vector2.right.x * speed;
        player.velocity = motion;
    }

    private void VerticalMovement(bool isGrounded)
    {
        // return if not grounded or not pressing space
        if (!isGrounded || !Input.GetButtonDown("Jump")) return;
        player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    private bool IsGrounded()
    {
        Vector2 center = collider.bounds.center;
        float offset = 0.25f;
        float detectionDistance = collider.bounds.extents.y + offset;

        // detect ground layer
        RaycastHit2D hit = Physics2D.Raycast(center, Vector2.down, detectionDistance, layer);
        Color color = hit.collider != null ? Color.green : Color.red;
        Debug.DrawRay(center, Vector2.down * detectionDistance, color);

        // return true if raycast hit ground
        return hit.collider != null;
    }
    #endregion

}
