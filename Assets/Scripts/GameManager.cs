using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private static int _nuggets = 0;
    private bool paused = false;
    private float _movement = 1.0f;
    private float currmov = 0.0f;

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
        Debug.Log(paused);
        if(SceneManager.GetActiveScene().name != "Game"){
            Pause();
        }
    }

    private void Pause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause_menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }

    public void EndPause(){
        pause_menu.SetActive(false);
        Time.timeScale = 1.0f;
        
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }

    public float SetMovement(float movement){
        _movement += movement;
        currmov = movement;
        return _movement;
    }

    public float GetMovement(){
        return currmov;
    }
    public void Quit(){
         Application.Quit();
    }

    public void Nuggets(int nugget_points){
        _nuggets = nugget_points;
    }

    public int Return_nuggets(){
        return _nuggets;
    }

    
}
