using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Head : MonoBehaviour
{
    public TMP_Text points;
    public int count;
    private int multiplier;
    GameObject go;
    Dino player = null;    
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find ("Dinosaur");
        player = go.GetComponent <Dino> ();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (other.gameObject.tag == "good") {
            count += 3 * multiplier;
        }
        else if (other.gameObject.tag == "raw") {
            count += 1 * multiplier;
        }
        else if (other.gameObject.tag == "bad") {
            count += 5 * multiplier;
        }
        points.text = "Points: " + count;
        other.GetComponent<SpriteRenderer>().enabled = false;
    }
}
