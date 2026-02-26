using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -50f)
        {
            Destroy(gameObject);
        }
    }
}
