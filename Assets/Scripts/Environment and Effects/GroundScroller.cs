using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    public Transform player;
    public int groundsOnScreen = 3;

    private Transform nextSpawnPoint;

    void Start()
    {
        nextSpawnPoint = transform; // start position

        for (int i = 0; i < groundsOnScreen; i++)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if (player.position.x > nextSpawnPoint.position.x - 40f)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        GameObject ground = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        GameObject spawned = Instantiate(ground, nextSpawnPoint.position, Quaternion.identity);

        nextSpawnPoint = spawned.transform.Find("SpawnPoint");
    }
}
