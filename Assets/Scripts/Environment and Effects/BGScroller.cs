using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool isScreen;
    public float width;
    public Rigidbody2D playerRB;
    public Transform cam;
    

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        
       
    }

    void Update()
    {

        if (playerRB.linearVelocity.x > 0.1f)
        {
            transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        }

        if (transform.position.x + width < cam.position.x)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}
