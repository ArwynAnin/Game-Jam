using UnityEngine;

public class Platforms : MonoBehaviour
{
    public bool IsActive
    {
        get { return gameObject.activeSelf; } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;
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
