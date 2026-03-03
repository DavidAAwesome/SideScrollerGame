using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool canJump = true; 
    public Animator anim; 
    [Header("PlayerStats")] 
    public float speed;

    [Header("Jump")] 
    public float jumpVelocity; 
    public float fallGravityMultiplier = 3f; 
    public float riseGravityMultiplier = 2f; 
    public int doubleJumpsAmmount = 1;
    
    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool grounded;
    private float baseGravity;
    private int doubleJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        baseGravity = rb.gravityScale;
    }

    void Start()
    {
        ScoreManager.Instance.StartRun();
        doubleJumps = doubleJumpsAmmount;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (grounded)
        {
            doubleJumps = doubleJumpsAmmount;
            anim.SetBool("isJumping", false);
            canJump = true;
        }

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
        {
            if (canJump)
            {
                anim.SetBool("isJumping", true);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
                canJump = false;
            }
        }
        else
        {
            if (doubleJumps > 0)
            {
                doubleJumps--;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = grounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void Die()
    {
        enabled = false;
        rb.linearVelocity = Vector2.zero;
        UIManager.Instance.ShowDeathScreen(ScoreManager.Instance.EndRunAndFinalizeScore());
    }
}