using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject scoreObject;
    ScoreManager manager ;
    public bool spawnerSpawn=true;
       public float spawnerTime=0;

    public string obj;
      public  GameObject Snake;
     public  GameObject Croc;
     public  GameObject Mosquito;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        scoreObject=GameObject.Find("ScoreManager");
       
        if(scoreObject.GetComponent<ScoreManager>().CurrentScore>500){
             if(obj=="Snake")
                gameObject.name="Mosquito";
              if(obj=="Mosquito"){
            
                Instantiate(Mosquito,new Vector3(transform.position.x+5,transform.position.y,transform.position.z),transform.rotation);

              }
          
            
        }
      
    }

    // Update is called once per frame
    void Update()
    {
               Debug.Log("Score"+ scoreObject.GetComponent<ScoreManager>().CurrentScore);

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
