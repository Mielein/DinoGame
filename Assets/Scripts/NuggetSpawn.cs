using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NuggetSpawn : MonoBehaviour
{
    private List<GameObject> nuggies;
    private List<GameObject> obss;
    public List<Sprite> obs1;
    public List<Sprite> obs2_1;
    public List<Sprite> obs2_2;
    public List<Sprite> obs3;
    private Quaternion scary;
    private bool spawned;
    private bool spawned2;
    private bool anim;
    public GameObject nuggie;
    public GameObject obs;
    public GameObject dino;
    Dino player = null;
    public float upper_bound;
    public float lower_bound;
    public float out_of_bounds;
    public float start_frequency;
    public float start_frequency2;
    public int set_prob;
    private float freq;
    private float speed;
    private int frames;
    private float time;
    private float timing;


    public List<Sprite> sprites;

    void Start()
    {
        nuggies = new List<GameObject>();
        obss = new List<GameObject>();
        spawned = false;
        spawned2 = false;
        Rigidbody2D body = dino.GetComponent<Rigidbody2D>();
        Collider2D collider = dino.GetComponent<Collider2D>();
        player = dino.GetComponent <Dino> ();
        frames = 0;
        time = 0.0f;
        timing = 0.0f;
        anim = false;
    }

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
            else if (gen_prob > (100 - set_prob)) {
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
        /// ---ä
        if (!spawned2 && interval % start_frequency2 == 0) {
            Debug.Log("Spawn Obstacle");
            int gen_prob = (int)UnityEngine.Random.Range(0, 100);
            Vector3 spawn = new Vector3(0.0f, (int)UnityEngine.Random.Range(upper_bound, lower_bound), 0.0f);
            GameObject tmp_obs = Instantiate(obs, spawn, scary);
            if (gen_prob < set_prob) {
                tmp_obs.tag = "obs-1";
                tmp_obs.GetComponent<SpriteRenderer>().sprite = obs1[0];
            }
            else if (gen_prob > (100 - set_prob)) {
                tmp_obs.tag = "obs-2";
                tmp_obs.GetComponent<SpriteRenderer>().sprite = obs2_1[0];
            }
            else {
                tmp_obs.tag = "obs-3";
                tmp_obs.GetComponent<SpriteRenderer>().sprite = obs3[0];
            }
            obss.Add(tmp_obs);
            spawned2 = true;
        }
        else if (spawned2 && interval % start_frequency2 != 0) {
            spawned2 = false;
        }
        time += UnityEngine.Time.deltaTime;
        anim = (time < 0.05f) ? false : true;
        for (int i = 0; i < obss.Count; ++i) {
            if (obss[i].transform.position.x > out_of_bounds) {
                obss[i].transform.position += new Vector3 (-speed * UnityEngine.Time.deltaTime, 0.0f, 0.0f);
                if (anim) {
                    if(obss[i].tag == "obs-1") {
                    obss[i].GetComponent<SpriteRenderer>().sprite = obs1[(int) (frames % (obs1.Count * 3)) / 3];
                    }
                    else if(obss[i].tag == "obs-2") {
                        obss[i].GetComponent<SpriteRenderer>().sprite = obs2_1[(int) (frames % (obs2_2.Count * 3)) / 3];
                    }
                    else if(obss[i].tag == "obs-3") {
                        obss[i].GetComponent<SpriteRenderer>().sprite = obs3[(int) (frames % (obs3.Count * 3)) / 3];
                    }
                }
            }
            else {
                Destroy(obss[i]);
                obss.Remove(obss[i]);
            }
        }
        frames = (frames + 1) % 100;
        if (anim) {
            anim = false;
            time = 0.0f;
            timing += 0.5f;
        }
        
    }
}
