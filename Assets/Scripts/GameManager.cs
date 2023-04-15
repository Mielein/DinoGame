using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private static int _nuggets = 0;


    public static GameManager Instance{
        get{
            if(_instance == null){
                Debug.LogError("GameManager is null");
            }
            return _instance;
             
        }
    }
    private void Awake(){
        _instance = this;
    }

    public void Nuggets(int nugget_points){
        _nuggets = nugget_points;
    }

    public int Return_nuggets(){
        return _nuggets;
    }

    
}
