using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [Header("Horizontal")]
    [SerializeField] private float offsetX = 3f;

    [Header("Vertical")]
    [SerializeField] private float baseY = 0f;             // default camera height
    [SerializeField] private float followThreshold = 2f;   // how high player must go before camera moves
    [SerializeField] private float maxYIncrease = 2f;      // max camera lift
    [SerializeField] private float verticalSmoothTime = 0.2f;

    [Header("General Smooth")]
    [SerializeField] private float smoothTime = 0.08f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (!target) return;

        float desiredY = baseY;

        float heightDifference = target.position.y - baseY;

        if (heightDifference > followThreshold)
        {
            float extra = Mathf.Clamp(
                heightDifference - followThreshold,
                0,
                maxYIncrease
            );

            desiredY = baseY + extra;
        }

        Vector3 desiredPosition = new Vector3(
            target.position.x + offsetX,
            desiredY,
            transform.position.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );
    }
}