using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public GameObject cam;
    private float length;
    private float startpos;
    public float parallax_effect;
    public float speed = 0.01f;

    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(GetComponent<SpriteRenderer>().bounds.size.x);
    }

    // Update is called once per frame
    void FixedUpdate() {
        float tmp = (cam.transform.position.x * (1 - parallax_effect));
        float dist = (GameManager.Instance.SetMovement(speed) * parallax_effect);
    
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if(tmp > startpos + length){
            startpos += length;
        }
        else if(tmp < startpos - length){
            startpos -= length;
        }
 
    }
}

