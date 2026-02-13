using UnityEngine;
using UnityEditor;
public class EnemyMovement:MonoBehaviour
{
    
    static float distanceB=0;
    static float distance=0;
    public static float time=0;
     bool timeUpwards=false;
    public float TimeBasedMove(float speed){
      
      Debug.Log(distanceB);
      if(distanceB>1){
        timeUpwards=false;
        distanceB=0;
        
      }
      if (distanceB<-1){
        timeUpwards=true;
        distanceB=0;
      }
      if (timeUpwards==false){
    
        distanceB-=Time.fixedDeltaTime;
        
        
      }
      else{
        
        distanceB+=Time.fixedDeltaTime;
      }
        return distanceB;
        
    }
     public float SpeedBasedMove(float speed){
        distance+=Time.deltaTime*-4*speed;
        return distance;
    }
    
   
}
