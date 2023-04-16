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
    int[] reps = new int[] {0, 0, 0, 0};

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
        multiplier = (int) (-200.0f * movement);
        Debug.Log(multiplier);
        bool hide = true;
        if (other.gameObject.tag == "good") {
            count += (int) (3.0f * multiplier);
        }
        else if (other.gameObject.tag == "raw") {
            count += (int) (1.0f * multiplier);
        }
        else if (other.gameObject.tag == "bad") {
            count += (int) (5.0f * multiplier);
        }
        if (other.gameObject.tag == "obs-1") {
            count -= (int) (1.0f * multiplier);
        }
        else if (other.gameObject.tag == "obs-2") {
            count -= (int) (2.0f * multiplier);
        }
        else if (other.gameObject.tag == "obs-3") {
            count -= (int) (3.0f * multiplier);
        }
        else if (other.gameObject.tag == "Road") {
            hide = false;
            GameObject tmp = Instantiate(road);
            reps[0] += 1;
            tmp.transform.position = new Vector3(roadspawn.transform.position.x + (100.0f * reps[0]), roadspawn.transform.position.y, roadspawn.transform.position.z);
            Destroy(other);
            Debug.Log("load road");
        }
        else if (other.gameObject.tag == "Front") {
            hide = false;
            GameObject tmp = Instantiate(front);
            reps[1] += 1;
            tmp.transform.position = new Vector3(frontspawn.transform.position.x + (58.0f * reps[1]), frontspawn.transform.position.y, frontspawn.transform.position.z);
            Destroy(other);
            Debug.Log("load front, " + tmp.transform.position);
            // move sprite
        }
        else if (other.gameObject.tag == "Middle") {
            hide = false;
            GameObject tmp = Instantiate(middle);
            reps[2] += 1;
            tmp.transform.position = new Vector3(middlespawn.transform.position.x + (58.0f * reps[2]), middlespawn.transform.position.y, middlespawn.transform.position.z);
            Destroy(other);
            Debug.Log("load middle");
            // move sprite
        }
        else if (other.gameObject.tag == "Back") {
            hide = false;
            GameObject tmp = Instantiate(back);
            reps[3] += 1;
            tmp.transform.position = new Vector3(backspawn.transform.position.x + (58.0f * reps[3]), backspawn.transform.position.y, backspawn.transform.position.z);
            Destroy(other);
            Debug.Log("load back");
            // move sprite
        }
        if (hide) {
            points.text = "Nuggies: " + count;
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
