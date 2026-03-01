using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == null) return;

        ScoreManager.Instance.AddBanana(1);
        Destroy(gameObject);
    }
}