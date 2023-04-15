using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> extend;
    public List<Sprite> breathe_low;
    public List<Sprite> breathe_high;

    private int stage;
    private bool end_stage; 
    private Rigidbody2D rbod;
    void Start()
    {
        stage = 0;
        rbod = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S)) {
            if (stage < 7) {
                stage ++;
                GetComponent<SpriteRenderer>().sprite = extend[stage];
                rbod.transform.position -= new Vector3(0.2f, 0.9f, 0.0f);
            }
        }
        if(Input.GetKey(KeyCode.W)) {
            if (stage > 0) {
                stage --;
                GetComponent<SpriteRenderer>().sprite = extend[stage];
                rbod.transform.position += new Vector3(0.2f, 0.9f, 0.0f);
            }
        }
    }
}
