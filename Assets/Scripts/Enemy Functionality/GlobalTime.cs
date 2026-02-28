using UnityEngine;

public class GlobalTime:MonoBehaviour
{
    public static float time=0;
    void FixedUpdate(){
        Debug.Log(time);
     time+=Time.fixedDeltaTime;
    }
}
