using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour {

    public GameObject[] vehicle_arr;
    public GameObject[] diff_arr;
    public Button left_button;
    public Button right_button;
    public Sprite burntnuggie_l;
    public Sprite burntnuggie_r;
    private int i = 0;

    void Start(){

    }

    void Update() {
        SetDiff(i);
        
    }

    public void SetDiff(int diff){

        foreach (var difficulty in diff_arr){
            if(System.Array.IndexOf(diff_arr, difficulty)<= diff){
                difficulty.SetActive(true);
            }
            else difficulty.SetActive(false);
            
        }
    }
        

    public void Right(){
        vehicle_arr[i].SetActive(false);
        i++;
        if(i >= vehicle_arr.Length){
            i=0;
        }
        vehicle_arr[i].SetActive(true);
    }    

    public void Left(){
        vehicle_arr[i].SetActive(false);
        i--;
        if(i < 0){
            i=4;
        }
        vehicle_arr[i].SetActive(true);
    }

    public void changeLeftButton(){
        left_button.GetComponent<Image>().sprite = burntnuggie_l;
    }
}
