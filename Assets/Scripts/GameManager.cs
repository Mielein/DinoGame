using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private static int _nuggets = 0;

    public GameObject pause_menu;


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

    void Update(){
        if(SceneManagement.Scene.name != "Game"){
            Pause();
        }
    }

    private void Pause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause_menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Nuggets(int nugget_points){
        _nuggets = nugget_points;
    }

    public int Return_nuggets(){
        return _nuggets;
    }

    
}
