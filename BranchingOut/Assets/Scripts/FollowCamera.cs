using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x > target.position.x) return;
        Vector3 offset = transform.position;
        offset.x = target.position.x;
        transform.position = offset;
    }
}
