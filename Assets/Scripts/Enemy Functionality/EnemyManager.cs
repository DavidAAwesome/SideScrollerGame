using UnityEngine;
using UnityEditor;
public class EnemyManager:MonoBehaviour
{
    public float speed=.4f;
    static Vector3 pos;
    EnemyMovement movement;
    
    public  Vector3 position;
  
    public string EnemyType;
    

    void Start(){
        movement=GetComponent<EnemyMovement>();
        position=transform.position;
       
    }
    void FixedUpdate(){
        if(EnemyType=="Mosquito"){
           transform.Translate(Time.deltaTime*movement.SpeedBasedMove(speed)*5,0,0);
        }
        else if(EnemyType=="Croc"){
            transform.position += new Vector3(0,Time.deltaTime*movement.TimeBasedMove(1)*5,0);
        }
        
    }
   
}
