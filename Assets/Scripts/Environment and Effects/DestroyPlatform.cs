using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.right * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Destroying: " + other.name);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
        }    
        
    }
}
