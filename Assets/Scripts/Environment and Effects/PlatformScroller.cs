using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;

    public BGScroller BGScroller;
    public Transform player;
    public float platformSpawnTime = 2f;
    public float timeUntilPlatform = 3f;
    private float lastPlayerX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPlayerX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float playerMove = player.position.x - lastPlayerX;
        if (playerMove > 0)
        {
            timeUntilPlatform -= Time.deltaTime;

            if (timeUntilPlatform < 0)
            {
                SpawnLoop();
                timeUntilPlatform = 3;
            }

        }

        lastPlayerX = player.position.x;

    }

    public void SpawnLoop()
    {
        GameObject platformSpawn = platform[Random.Range(0, platform.Length)];
        GameObject spawnedPlatform = Instantiate(platformSpawn, transform.position, Quaternion.identity);

        Rigidbody2D platformRB = spawnedPlatform.GetComponent<Rigidbody2D>();
        platformRB.linearVelocity = Vector2.left * 2;
    }    
}
