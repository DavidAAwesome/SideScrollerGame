using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BGScroller : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField, Range(0f, 1f)] private float parallaxMultiplier = 0.3f;

    // Optional: helps prevent seams due to floating point / texture filtering
    [SerializeField] private float seamFix = 0.01f;

    private float width;
    private float startX;

    void Awake()
    {
        var sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        startX = transform.position.x;

        if (cam == null)
            cam = Camera.main.transform;
    }

    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().bounds.size.x);
    }

    void LateUpdate()
    {
        // Parallax position for THIS tile
        float parallaxX = cam.position.x * parallaxMultiplier;
        transform.position = new Vector3(startX + parallaxX - 1, transform.position.y, transform.position.z);

        // How far the camera has moved relative to this tile at "world speed"
        float camRelativeX = cam.position.x * (1f - parallaxMultiplier);

        // If the camera has moved far enough that this tile is a whole width behind, wrap it forward
        if (camRelativeX > startX + width + seamFix)
        {
            startX += width * 2f; // because you have 2 tiles
        }
        else if (camRelativeX < startX - width - seamFix)
        {
            startX -= width * 2f;
        }
    }
}