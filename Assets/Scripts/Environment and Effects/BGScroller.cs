using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool isScreen;
    public float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
       
    }

    void Update()
    {
     
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);



        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}
