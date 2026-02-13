using UnityEngine;
using UnityEditor;
public class EnemyData:MonoBehaviour
{
    
    public static Object Snake;
     public static Object Croc;
     public static Object Mosquito;
    void Awake(){
        

    }
    public static void InitializeEnemyAssets(){
        Snake = AssetDatabase.LoadAssetAtPath("Assets/Prefebs/Enemies/Snake.prefab",typeof(GameObject));
        Croc = AssetDatabase.LoadAssetAtPath("Assets/Prefebs/Enemies/Croc.prefab",typeof(GameObject));
        Mosquito = AssetDatabase.LoadAssetAtPath("Assets/Prefebs/Enemies/Mosquito.prefab",typeof(GameObject));
    }
    public static Vector3 EnemyPosition(Vector3 position){
        return position;
    }
}

