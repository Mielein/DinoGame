using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class head : MonoBehaviour
{
    public TMP_Text points;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
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
