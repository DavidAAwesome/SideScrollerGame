using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    public Animator anim;

    [Header("PlayerStats")]
    public float speed;

    [Header("Jump")]
    public float jumpVelocity = 12f;                // base jump
    [Range(0.1f, 1f)] public float doubleJumpScale = 0.75f; // double jump is lower (e.g., 75% height)
    public float fallGravityMultiplier = 3f;
    public float riseGravityMultiplier = 2f;
    public int doubleJumpsAmmount = 1;

    [Header("Double Jump Cloud FX")]
    public SpriteRenderer cloudFxRenderer;          // assign a child SpriteRenderer under player OR a prefab instance
    public Sprite[] cloudSprites = new Sprite[4];   // assign 4 sprites in Inspector
    public float cloudLifetime = 0.12f;             // disappears right after (seconds)
    public Vector2 cloudOffset = new Vector2(0f, -0.6f);

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool grounded;
    private float baseGravity;
    private int doubleJumps;
    private float cloudTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        baseGravity = rb.gravityScale;

        // If you use a SpriteRenderer for the cloud, start hidden
        if (cloudFxRenderer != null)
            cloudFxRenderer.enabled = false;
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

        // handle cloud lifetime
        if (cloudFxRenderer != null && cloudFxRenderer.enabled)
        {
            cloudTimer -= Time.deltaTime;
            if (cloudTimer <= 0f)
                cloudFxRenderer.enabled = false;
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

                // lower double jump height
                float djVel = jumpVelocity * doubleJumpScale;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, djVel);

                // spawn/show random cloud sprite under player briefly
                PlayDoubleJumpCloud();
            }
        }
    }

    private void PlayDoubleJumpCloud()
    {
        if (cloudFxRenderer == null) return;
        if (cloudSprites == null || cloudSprites.Length == 0) return;

        // choose one of the first 4 sprites (or fewer if you assigned fewer)
        int count = Mathf.Min(4, cloudSprites.Length);
        int idx = Random.Range(0, count);

        cloudFxRenderer.sprite = cloudSprites[idx];
        cloudFxRenderer.transform.position = (Vector2)transform.position + cloudOffset;
        cloudFxRenderer.enabled = true;
        cloudTimer = cloudLifetime;
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