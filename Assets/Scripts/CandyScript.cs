using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Monster")
         {
            Destroy(gameObject);
            /*Debug.Log("Enter " + collision.gameObject);
            Debug.Log("Sticking to a Tile");*/
        }
        /*else if (collision.CompareTag("Candy"))
        {
            //audio.PlayOneShot(lootCandy);
        }*/
    }
}

