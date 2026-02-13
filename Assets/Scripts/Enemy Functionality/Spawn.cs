using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyData.InitializeEnemyAssets();
         if(obj=="Snake")
        Instantiate(EnemyData.Snake,transform.position,transform.rotation);
    
        if(obj=="Mosquito")
        Instantiate(EnemyData.Mosquito,transform.position,transform.rotation);

         if(obj=="Croc")
        Instantiate(EnemyData.Croc,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    
    }
}
