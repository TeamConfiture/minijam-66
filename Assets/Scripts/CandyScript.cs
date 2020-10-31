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
        Debug.Log("Sloubie0");
        if (collision.tag == "Monster") {
            Debug.Log("Sloubie1");
            Destroy(gameObject);
            Debug.Log("Sloubie2");
            /*Debug.Log("Enter " + collision.gameObject);
            Debug.Log("Sticking to a Tile");*/
        } /*else if (collision.CompareTag("Candy"))
        {
            //audio.PlayOneShot(lootCandy);
        }*/
    }
}

