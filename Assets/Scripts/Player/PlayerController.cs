using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerStats")]
    public float speed;
    
    [Header("Jump")]
    public float jumpVelocity;
    public float fallGravityMultiplier = 3f;
    public float riseGravityMultiplier = 2f;
    
    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool grounded;
    private float baseGravity;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        baseGravity = rb.gravityScale;
    }
    
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (transform.position.y <= -5)
            Die();
    }

    private void FixedUpdate()
    {
        // constant right movement
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        
        // better jump gravity
        if (rb.linearVelocity.y < 0)
            rb.gravityScale = baseGravity * fallGravityMultiplier;
        else if (rb.linearVelocity.y > 0)
            rb.gravityScale = baseGravity * riseGravityMultiplier;
        else
            rb.gravityScale = baseGravity;
    }

    void OnJump()
    {
        if (grounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
    }
    
    void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = grounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    
    public void Die()
    {
        enabled = false;              // disables this script
        rb.linearVelocity = Vector2.zero;   // stop motion
        UIManager.Instance.ShowDeathScreen();
    }


}
