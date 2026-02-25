using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;

    public Transform player;
    public float groundWidth = 30f;
    public int groundsOnScreen = 3;

    private float spawnX;

    void Start()
    {
        spawnX = transform.position.x;

        for (int i = 0; i < groundsOnScreen; i++)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if (player.position.x + (groundWidth * 2) > spawnX)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        GameObject ground = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        Instantiate(ground, new Vector3(spawnX, transform.position.y, 0), Quaternion.identity);

        spawnX += groundWidth;
    }
}
