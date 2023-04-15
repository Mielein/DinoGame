using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> extend;
    public List<Sprite> idle_low;
    public List<Sprite> idle_high;
    public List<Sprite> rolling;

    private int stage;
    private int status; 
    private Rigidbody2D rbod;
    private SpriteRenderer srend;
    private SpriteRenderer sfeet;
    private float time;
    private int frames;
    public int transport;
    
    public GameObject roller;
    private List<Vector3> hardcode_hitbox = new List<Vector3>();

    void Ohno() {
        hardcode_hitbox.Add(new Vector3(0.15f, 1.0f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.1f, 1.2f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.1f, 1.1f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.0f, 0.9f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.4f, 0.7f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.2f, 0.4f, 0.0f));
        hardcode_hitbox.Add(new Vector3(0.2f, 0.2f, 0.0f));
    }
    void Start()
    {
        Ohno();
        frames = 0;
        time = 0.0f;
        stage = 0;

        rbod = GetComponentInChildren<Rigidbody2D>();
        srend = GetComponent<SpriteRenderer>();
        sfeet = roller.GetComponent<SpriteRenderer>();
        roller.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.0f);
        roller.transform.localScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S)) {
            status = 1;
        }
        else if(Input.GetKey(KeyCode.W)) {
            status = -1;
        }

        time += UnityEngine.Time.deltaTime;
        if (time < 0.05f) {
            return;
        }
        time = 0.0f;
        switch (status) {
            case 1:
                Shrink();
                break;
            case 2:
                srend.sprite = idle_low[(int) (frames * 0.5f) % idle_low.Count];
                break;
            case -1:
                Grow();
                break;
            case -2:
                srend.sprite = idle_high[(int) (frames * 0.5f) % idle_high.Count];
                break;
        }
        switch (transport) {
            case 1:
                sfeet.sprite = rolling[(int) (frames * 0.5f) % rolling.Count];
                break;
            case 0:
                sfeet.sprite = null;
                break;
        }
        frames = (frames + 1) % 100;
    }
    void Shrink() {
        status = (stage + 1 >= 7) ? 2 : 1;
        if (stage < 7) {
            stage ++;
            rbod.transform.position -= hardcode_hitbox[stage - 1];
            srend.sprite = extend[stage];
        }
    }
    void Grow() {
        status = (stage -1 <= 0) ? -2 : -1;
        if (stage > 0) {
            stage --; 
            srend.sprite = extend[stage];
            rbod.transform.position += hardcode_hitbox[stage];
        }
    }
}
