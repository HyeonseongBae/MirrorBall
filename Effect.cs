using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Transform player;
    public Transform aura;

    public ParticleSystem redPs;
    public ParticleSystem bluePs;

    AudioSource redAudio;
    AudioSource blueAudio;

    public bool overlap = false;

    Vector3 auraPos = new Vector3();

    private void Start()
    {
       // player = GameObject.Find("Player").transform;
         aura = GameObject.Find("Aura").transform;
        //redPs = GameObject.Find("RedEffect").GetComponent<ParticleSystem>();
        //bluePs = GameObject.Find("BlueEffect").GetComponent<ParticleSystem>();

        redAudio = redPs.GetComponent<AudioSource>();
        blueAudio = bluePs.GetComponent<AudioSource>();

        redPs.Stop();
        bluePs.Stop();

        //Instantiate(aura,new Vector3(10,0,0),Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
        {
            NoteEffect();
        }

        aura.transform.position = new Vector3(CreateTile.S.que_TileObj.Peek().transform.position.x, 0.5f, CreateTile.S.que_TileObj.Peek().transform.position.z);
    }

    void NoteEffect()
    {
        float distance = Vector3.Distance(player.position, aura.transform.position); // 거리 계산

        Debug.Log(distance);

        if (distance <= 1.5 && distance >= 0) //distance <= 0.5 && distance >= 0
        {
            bluePs.Play();
            blueAudio.Play();
        }
        else if (distance <= 2.5 && distance > 1.5) //distance <= 1.5 && distance > 0.25
        {
            redPs.Play();
            redAudio.Play();
        }
    }
}
