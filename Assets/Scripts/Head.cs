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

    public GameObject road;
    public GameObject front;
    public GameObject middle;
    public GameObject back;
    private Quaternion quat;

    public GameObject roadspawn;
    public GameObject frontspawn;
    public GameObject middlespawn;
    public GameObject backspawn;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find ("Dinosaur");
        player = go.GetComponent <Dino> ();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.Nuggets(count);
    }
    void OnTriggerEnter2D(Collider2D other) {
        float movement = GameManager.Instance.GetMovement();
        Debug.Log("idk");
        bool hide = true;
        if (other.gameObject.tag == "good") {
            count += (int) (3.0f * movement);
        }
        else if (other.gameObject.tag == "raw") {
            count += (int) (1.0f * movement);
        }
        else if (other.gameObject.tag == "bad") {
            count += (int) (5.0f * movement);
        }
        if (other.gameObject.tag == "obs-1") {
            count -= (int) (1.0f * movement);
        }
        else if (other.gameObject.tag == "obs-2") {
            count += (int) (2.0f * multiplier);
        }
        else if (other.gameObject.tag == "obs-3") {
            count += (int) (3.0f * multiplier);
        }
        else if (other.gameObject.tag == "Road") {
            hide = false;
            Instantiate(road);
            Destroy(other);
            Debug.Log("load road");
        }
        else if (other.gameObject.tag == "Front") {
            hide = false;
            GameObject tmp = Instantiate(front);
            tmp.transform.position = frontspawn.transform.position/* new Vector3(frontspawn.transform.position.x + 60.0f, frontspawn.transform.position.y, frontspawn.transform.position.z) */;
            //Destroy(other);
            Debug.Log("load front");
            // move sprite
        }
        else if (other.gameObject.tag == "Middle") {
            hide = false;
            Instantiate(middle);
            Destroy(other);
            Debug.Log("load middle");
            // move sprite
        }
        else if (other.gameObject.tag == "Back") {
            hide = false;
            Instantiate(back);
            Destroy(other);
            Debug.Log("load back");
            // move sprite
        }
        points.text = "Nuggies: " + count;
        if (hide) {
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
