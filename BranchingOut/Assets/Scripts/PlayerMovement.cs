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

    private CapsuleCollider2D collider;
    private Rigidbody2D player;

    protected Platforms plant;

    protected bool spawning;
    protected bool canSpawn;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        canSpawn = true;
        spawning = false;
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        VerticalMovement(IsGrounded());
    }
    #endregion

    #region Movements
    private void HorizontalMovement()
    {
        if (spawning && plant != null) return;

        // set horizontal motion so to not affect vertical motion
        Vector2 motion = player.velocity;
        motion.x = Vector2.right.x * speed;
        player.velocity = motion;
    }

    private void VerticalMovement(bool isGrounded)
    {
        // return if not grounded or not pressing space
        if (!isGrounded || !Input.GetButtonDown("Jump") || spawning) return;
        player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    private bool IsGrounded()
    {
        Vector2 center = collider.bounds.center;
        float ray = 0.25f;
        float detectionDistance = collider.bounds.extents.y + ray;

        // detect ground layer
        RaycastHit2D hit = Physics2D.Raycast(center, Vector2.down, detectionDistance, layer);
        Color color = hit.collider != null ? Color.green : Color.red;
        Debug.DrawRay(center, Vector2.down * detectionDistance, color);

        // return true if raycast hit ground
        return hit.collider != null;
    }
    #endregion

}
