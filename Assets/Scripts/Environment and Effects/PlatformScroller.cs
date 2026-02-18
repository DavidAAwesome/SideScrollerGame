using UnityEngine;


public class PlatformScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;
    public float platformSpawnTime = 2f;
    public float platformSpeed = 1f;
    private float timeUntilPlatformSpawn;

    void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilPlatformSpawn += Time.deltaTime;

        if(timeUntilPlatformSpawn >= platformSpawnTime)
        {
            Spawn();
            timeUntilPlatformSpawn = 0;
        }
    }

    private void Spawn()
    {
        GameObject platformToSpawn = platform[Random.Range(0, platform.Length)];
        GameObject spawnedPlatform = Instantiate(platformToSpawn,transform.position,Quaternion.identity);

        Rigidbody2D platformRB = spawnedPlatform.GetComponent<Rigidbody2D>();
        platformRB.linearVelocity = Vector2.left * platformSpeed;
    }
   
}

