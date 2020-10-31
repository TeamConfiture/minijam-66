using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel0 : MonoBehaviour
{

    private Rigidbody2D spawns ;
    public int nbEnemy = 1;
    public Rigidbody2D enemy1;
    public float enemySpeed = 500f;


    // Start is called before the first frame update
    void Start()
    {
        Transform[] tab = spawns.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(nbEnemy > 0){
            SpawnEnemy1();
            nbEnemy--;
        }
    }

    
    void SpawnEnemy1()
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
