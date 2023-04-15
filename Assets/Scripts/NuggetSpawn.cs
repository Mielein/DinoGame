using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NuggetSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> nuggies;
    private Quaternion scary;
    private bool spawned;
    public GameObject nuggie;
    public GameObject dino;
    Dino player = null;
    public float upper_bound;
    public float lower_bound;
    public float out_of_bounds;
    public float start_frequency;
    public int set_prob;
    private float freq;
    private float speed;

    public List<Sprite> sprites;

    void Start()
    {
        nuggies = new List<GameObject>();
        spawned = false;
        Rigidbody2D body = dino.GetComponent<Rigidbody2D>();
        Collider2D collider = dino.GetComponent<Collider2D>();
        player = dino.GetComponent <Dino> ();
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.transport) {
            case 0:
                freq = start_frequency;
                speed = 5.0f;
                break;
            case 1:
                freq = start_frequency * 1.5f;
                speed = 5.0f * 1.25f;
                break;
        }
        int interval = (int) (UnityEngine.Time.time * start_frequency);
        if (!spawned && interval % start_frequency == 0) {
            Debug.Log("Spawn");
            int gen_prob = (int)UnityEngine.Random.Range(0, 100);
            Vector3 spawn = new Vector3(0.0f, (int)UnityEngine.Random.Range(upper_bound, lower_bound), 0.0f);
            GameObject tmp_nugget = Instantiate(nuggie, spawn, scary);
            if (gen_prob < set_prob) {
                tmp_nugget.tag = "bad";
                tmp_nugget.GetComponent<SpriteRenderer>().sprite = (gen_prob % 2 == 0) ? sprites[4] : sprites[5];
                tmp_nugget.transform.localScale = new Vector3(0.75f, 0.75f, 1.0f);
            }
            if (gen_prob > (100 - set_prob)) {
                tmp_nugget.tag = "raw";
                tmp_nugget.GetComponent<SpriteRenderer>().sprite = (gen_prob % 2 == 0) ? sprites[0] : sprites[1];
                tmp_nugget.transform.localScale = new Vector3(1.25f, 1.25f, 1.0f);
            }
            else {
                tmp_nugget.tag = "good";
                tmp_nugget.GetComponent<SpriteRenderer>().sprite = (gen_prob % 2 == 0) ? sprites[2] : sprites[3];
            }
            nuggies.Add(tmp_nugget);
            spawned = true;
        }
        else if (spawned && interval % start_frequency != 0) {
            spawned = false;
        }
        for (int i = 0; i < nuggies.Count; ++i) {
            if (nuggies[i].transform.position.x > out_of_bounds) {
                nuggies[i].transform.position += new Vector3 (-speed * UnityEngine.Time.deltaTime, 0.0f, 0.0f);
            }
            else {
                Destroy(nuggies[i]);
                nuggies.Remove(nuggies[i]);
            }
        } 
    }
}
