using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel0 : MonoBehaviour
{

    private Rigidbody2D spawns ;
    public int nbWaveEnemies = 1;
    public int padding = 2;
    public Rigidbody2D enemy1;
    public float enemySpeed = 500f;


    // Start is called before the first frame update
    void Start()
    {
        Transform[] tab = spawns.GetComponentsInChildren<Transform>();
        // x <= abs(espacement + padding_x + background.width/2)
        // y < -background/2 - padding_y - espacement
        for(int i = 0; i <= nbWaveEnemies; i++)
        {
            Vector3 backgroundCo = GetComponent<Renderer>().bounds.size;
            Vector3 AllowedCo = new Vector3(backgroundCo[0]/2 + padding, backgroundCo[1]/2 + padding, backgroundCo[2]);
            if(nbWaveEnemies > 0){
              SpawnEnemy1(AllowedCo, 10);
              nbWaveEnemies--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
    void SpawnEnemy1(Vector3 AllowedCo, int espacement)
    {
        Vector3 spawnPosition = new Vector3(-2.5f,0f,0f);
        var direction = spawnPosition - transform.position ;
        direction.z = 0;

        //direction.Normalize();

        Debug.Log(direction);

        Rigidbody2D Enemy1 = Instantiate(enemy1, spawnPosition, transform.rotation);
        enemy1.AddForce(direction * enemySpeed);

    }
}
