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
    public AudioSource audio;

    public bool skateboard;
    public bool scooter;
    public bool car;
    public bool plane;

    public GameObject skatelock;
    public GameObject scootlock;
    public GameObject carlock;
    public GameObject planelock;


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
        
        if(SceneManager.GetActiveScene().name != "Game"){
            Pause();
        }

        NuggetCount();
    }

    public void NuggetCount(){
        if(_nuggets >= 100){
            skateboard = true;

        }
        if(_nuggets >= 200){
            scooter = true;
        }
        if(_nuggets >= 300){
            car = true;
        }
        if(_nuggets >= 400){
            plane = true;
        }
    }

    public void Unlock(){
        if(skateboard){
            skatelock.SetActive(false);
            SetMovement(-0.1f);
        }
        if(scooter){
            scootlock.SetActive(false);
            SetMovement(-0.2f);
        }
        if(car){
            carlock.SetActive(false);
            SetMovement(-0.2f);
        }anager.cs
Automatic merge failed; fix conflicts and 
        if(plane){
            planelock.SetActive(false);
            SetMovement(-0.2f);
        }
    }

    private void Pause(){
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause_menu.SetActive(true);
            Time.timeScale = 0.0f;
            audio.volume = 0.3f;
        }
        
    }


    public void EndPause(){
        pause_menu.SetActive(false);
        Time.timeScale = 1.0f;
        audio.volume = 0.5f;
        
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
