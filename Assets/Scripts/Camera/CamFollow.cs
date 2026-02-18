using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;     
    public float smoothSpeed = 5f;
    public float offsetX = 2f;  
    public float offsetY = 1f;

    void Update()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(
            player.position.x + offsetX,
            player.position.y + offsetY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
