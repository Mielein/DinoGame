using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private float length;
    private float startpos;
    public GameObject cam;
    public float parallax_effect;

    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float dist = (cam.transform.position.x + parallax_effect);
    
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
 
    }
}

