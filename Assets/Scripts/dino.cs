using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dino : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text points;
    private int count;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("idk");
        if (other.gameObject.tag == "good") {
            count += 3;
        }
        else if (other.gameObject.tag == "raw") {
            count += 1;
        }
        else if (other.gameObject.tag == "bad") {
            count += 5;
        }
        points.text = "" + count;
        other.GetComponent<SpriteRenderer>().enabled = false;
    }
}
