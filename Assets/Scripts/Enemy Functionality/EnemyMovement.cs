using UnityEngine;
using UnityEditor;
public class EnemyMovement:MonoBehaviour
{
    Animator GatorOnlyanim;
    static float distanceB=0;
    static float distance=0;
    public static float time=0;
     bool timeUpwards=false;
    public float TimeBasedMove(float speed){
      if(GetComponent<Animator>()!=null&&name.Contains("Gator"))
        GatorOnlyanim=GetComponent<Animator>();
      Debug.Log(distanceB);
      if(distanceB>1){
           if (GatorOnlyanim!=null)
        GatorOnlyanim.SetBool("gatorUp",false);
        timeUpwards=false;
        distanceB=0;
        
        
      }
      if (distanceB<-1){
        if (GatorOnlyanim!=null)
        GatorOnlyanim.SetBool("gatorUp",true);
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
