using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool isScreen;
    public float width;
    public Transform player;
    public float lastPlayerLocation;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        lastPlayerLocation = player.position.x;
       
    }

    void Update()
    {
        float playerMove = player.position.x - lastPlayerLocation;

        if (playerMove > 0)
        {
            transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        }
     
        



        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}
