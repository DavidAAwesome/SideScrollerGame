using UnityEngine;

public class Spawn : MonoBehaviour
{
    public bool spawnerSpawn=true;
       public float spawnerTime=0;

    public string obj;
      public  GameObject Snake;
     public  GameObject Croc;
     public  GameObject Mosquito;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
       
      if(GlobalTime.time>spawnerTime&&spawnerSpawn==true){
          
            if(obj=="Snake")
            Instantiate(Snake,transform.position,transform.rotation);
        
            if(obj=="Mosquito"){
            Instantiate(Mosquito,transform.position,transform.rotation);
            }

            if(obj=="Croc")
            Instantiate(Croc,transform.position,transform.rotation);
            spawnerSpawn=false;
        }
    }
}
