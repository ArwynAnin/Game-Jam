using UnityEngine;

public class Platforms : MonoBehaviour
{
    public bool IsActive
    {
        get { return gameObject.activeSelf; } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!(other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("MainCamera"))) return;
        Despawn();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floating Island")) return;
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
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
