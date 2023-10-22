using UnityEngine;

public class FloatingIslands : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;

    public bool IsActive
    {
        get { return gameObject.activeSelf; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("MainCamera")) return;
        Despawn();
    }

    public void Despawn()
    {
        this.gameObject.SetActive(false);
    }

    public void Spawn()
    {
        this.gameObject.SetActive(true);
    }
}
