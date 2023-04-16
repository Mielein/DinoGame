using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public GameObject cam;
    public float length;
    private float startpos;
    public float parallax_effect;
    public float speed = 0.01f;

    void Start() {
        startpos = transform.position.x;
    }
    void FixedUpdate() {
        float tmp = (transform.position.x * (1 - parallax_effect));
        float dist = (GameManager.Instance.SetMovement(speed) * parallax_effect);
    
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }
/*          Debug.Log("startpos - length " + (startpos - length));
         Debug.Log("tmp "+ tmp); */


}

