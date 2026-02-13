using UnityEngine;
using UnityEditor;
public class EnemyMovement:MonoBehaviour
{
    
    static float distanceB=0;
    static float distance=0;
    public static float time=0;
     bool timeDown=false;
    public float TimeBasedMove(float speed){
      
      Debug.Log(distanceB);
      if(distanceB>.6f){
        timeDown=true;
        distanceB=0;
        
      }
      if (distanceB<-.6f){
        timeDown=false;
        distanceB=0;
      }
      if (timeDown==true){
        distanceB-=Time.deltaTime;
      }
      else{
        distanceB+=Time.deltaTime;
      }
        return distanceB;
        
    }
     public float SpeedBasedMove(float speed){
        distance+=Time.deltaTime*-4*speed;
        return distance;
    }
    
   
}
