using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvas : MonoBehaviour {

    public GameObject[] vehicle_arr;
    public GameObject[] diff_arr;
    private int i = 0;

    void Start(){
       

    }

    void Update() {
        for(int j = 0; j<= i; j++){
            diff_arr[j].SetActive(true);
        }
        
    }

    public void Right(){
        
        Debug.Log(i);
        vehicle_arr[i].SetActive(false);
        i++;
        if(i >= vehicle_arr.Length){
            i=0;
        }
        vehicle_arr[i].SetActive(true);
    }    

    public void Left(){
        Debug.Log(i);
        vehicle_arr[i].SetActive(false);
        i--;
        if(i < 0){
            i=4;
        }
        vehicle_arr[i].SetActive(true);
    }
}
