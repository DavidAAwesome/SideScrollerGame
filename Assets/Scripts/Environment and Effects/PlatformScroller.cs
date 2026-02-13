using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;

    public BGScroller BGScroller;
    public float platformSpawnTime = 2f;
    public float timeUntilPlatform = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilPlatform -= Time.deltaTime;

        if (timeUntilPlatform < 0)
        {
            SpawnLoop();
            timeUntilPlatform = 3;
        }
        
    }

    public void SpawnLoop()
    {
        GameObject platformSpawn = platform[Random.Range(0, platform.Length)];
        GameObject spawnedPlatform = Instantiate(platformSpawn, transform.position, Quaternion.identity);

        Rigidbody2D platformRB = spawnedPlatform.GetComponent<Rigidbody2D>();
        platformRB.linearVelocity = Vector2.left * 2;
    }    
}
