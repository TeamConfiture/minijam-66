using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVictory : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource music;

    public GameObject Part1;
    public GameObject Part2;

    public bool loop;
    public float musicVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        music.loop = loop;
        music.clip = clip;
        music.volume = musicVolume;
        music.Play();
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Victoire")
        {
            Part2.SetActive(false);
            Part1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}