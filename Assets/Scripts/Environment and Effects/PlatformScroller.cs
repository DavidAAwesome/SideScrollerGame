using UnityEngine;


public class PlatformScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;

    public Transform player;
    public float moveSpeed = 6f;

    public float minGap = 8f;
    public float maxGap = 14f;
    public float spawnY = 0f;

    private float lastSpawnX;
    private float timer;

    void Start()
    {
        lastSpawnX = transform.position.x;
        SpawnPlatform();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        float gap = Random.Range(minGap, maxGap);
        lastSpawnX += gap;

        GameObject p = platform[Random.Range(0, platform.Length)];
        GameObject spawned = Instantiate(p, new Vector3(lastSpawnX, spawnY, 0), Quaternion.identity);

        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * moveSpeed;
    }
}

