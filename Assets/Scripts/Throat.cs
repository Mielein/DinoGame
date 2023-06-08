using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Throat : MonoBehaviour
{
    public TMP_Text points;
    public int count;
    private int multiplier;
    GameObject go;
    Dino player = null;    
    void Start()
    {
        go = GameObject.Find ("Dinosaur");
        player = go.GetComponent <Dino> ();
    }

    void OnTriggerEnter2D(Collider2D other) {
        switch (player.transport) {
            case 0:
                multiplier = 1;
                break;
            case 1:
                multiplier = 2;
                break;
        }
        Debug.Log("idk");
        if (other.gameObject.tag == "obs-1") {
            count -= 1 * multiplier;
        }
        else if (other.gameObject.tag == "obs-2") {
            count -= 2 * multiplier;
        }
        else if (other.gameObject.tag == "obs-3") {
            count -= 3 * multiplier;
        }
        points.text = "Points: " + count + " " + multiplier;
        //other.GetComponent<SpriteRenderer>().enabled = false;
    }
}
