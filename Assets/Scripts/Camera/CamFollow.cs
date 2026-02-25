using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.08f;
    [SerializeField] private float offsetX = 3f;
    [SerializeField] private float fixedY = 0f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = new Vector3(
            target.position.x + offsetX,
            fixedY,
            transform.position.z
        );
        
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
    }
}
