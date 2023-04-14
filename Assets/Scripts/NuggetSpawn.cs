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
    public float upper_bound;
    public float lower_bound;
    public float start_frequency;
    public TMP_Text points;
    void Start()
    {
        nuggies = new List<GameObject>();
        spawned = false;   
    }

    // Update is called once per frame
    void Update()
    {
        int interval = (int) (UnityEngine.Time.time * 10);
        if (!spawned && interval % start_frequency == 0) {
            Debug.Log("Spawn");
            Vector3 spawn = new Vector3(0.0f, (int)UnityEngine.Random.Range(upper_bound, lower_bound), 0.0f);
            nuggies.Add((GameObject)Instantiate(nuggie, spawn, scary));
            spawned = true;
        }
        else if (spawned && interval % start_frequency != 0) {
            spawned = false;
        }
        for (int i = 0; i < nuggies.Count; ++i) {
            nuggies[i].transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
        } 
    }

    void onTriggerEnter() {

    }
}
