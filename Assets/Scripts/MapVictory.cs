﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVictory : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource music;
    public float musicVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        music.loop = true;
        music.clip = clip;
        music.volume = musicVolume;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
