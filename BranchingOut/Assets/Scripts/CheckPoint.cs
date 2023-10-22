using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Tree tree;
    Rigidbody2D rb;

    public bool IsActive
    {
        get { return gameObject.activeSelf; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("MainCamera")) return;
        tree.Spawn();
        Despawn();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
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
