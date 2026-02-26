using UnityEngine;
using TMPro;
public class CollectibleManager : MonoBehaviour
{
    public static TMP_Text text;
    public static float CollectibleAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Collect(){
         Destroy(gameObject);
        CollectibleAmount+=1;
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
