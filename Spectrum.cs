using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    public AudioSource audioSource;

    public int index;
    public float power;
    public float cycleTime;
    float[] current = new float[64];
    float curTime = 0;

    private int rotNum = 0;

    


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SearchSpectrum();

    }

    private void Start()
    {
        ChangeMusic();
    }

    private void Update()
    {
        if (curTime > cycleTime)
        {
            SearchSpectrum();
            curTime = 0;
        }
        curTime += Time.deltaTime;
    }


    void SearchSpectrum()
    {
        audioSource.GetSpectrumData(current, 0, FFTWindow.Rectangular);
        //print(current[index]);
        if (current[index] >= power)
        {
            int rand = Random.Range(-1, 2);
            switch (rand)
            {
                case 0:
                    break;
                case -1:
                    if (rotNum <= -2)
                    {
                        CreateTile.S.Tile_Turn(RIGHT_LEFT.TYPE_RIGHT);
                        rotNum++;
                    }
                    else
                    {
                        CreateTile.S.Tile_Turn(RIGHT_LEFT.TYPE_LEFT);
                        rotNum--;
                    }
                    break;
                case 1:
                    if (rotNum >= 2)
                    {
                        CreateTile.S.Tile_Turn(RIGHT_LEFT.TYPE_LEFT);
                        rotNum--;
                    }
                    else
                    {
                        CreateTile.S.Tile_Turn(RIGHT_LEFT.TYPE_RIGHT);
                        rotNum++;
                    }
                    break;
                default:
                    Debug.Log("Spectrum Tile_Ture Error!!");
                    return;
            }
        }
    }


    void ChangeMusic()
    {
        if (StartSceneManager.S.Type == StartSceneManager.MusicType.A)
        {
            audioSource.clip = StartSceneManager.S.AM;
            audioSource.Play();
        }
        if (StartSceneManager.S.Type == StartSceneManager.MusicType.B)
        {
            audioSource.clip = StartSceneManager.S.BM;
            audioSource.Play();
        }
        if (StartSceneManager.S.Type == StartSceneManager.MusicType.C)
        {
            audioSource.clip = StartSceneManager.S.CM;
            audioSource.Play();
        }
        if (StartSceneManager.S.Type == StartSceneManager.MusicType.D)
        {
            audioSource.clip = StartSceneManager.S.DM;
            audioSource.Play();
        }
    }


    }
