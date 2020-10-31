using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel0 : MonoBehaviour
{

    //public Rigidbody2D spawns ;
    public int nbWaveEnemies = 3;
    public int padding = 2;
    public Rigidbody2D enemy1;
    public float enemySpeed = 500f;

    public float spawnWidth = 1.4f;


    // Start is called before the first frame update
    void Start()
    {
        //Transform[] tab = spawns.GetComponentsInChildren<Transform>();
        // x <= abs(espacement + padding_x + background.width/2)
        // y < -background/2 - padding_y - espacement
        Vector3 backgroundCo = GetComponent<Renderer>().bounds.size;
        Vector3 AllowedCo = new Vector3(backgroundCo[0]/2 + padding, backgroundCo[1]/2 + padding, backgroundCo[2]);
        for(int i = 0; i <= nbWaveEnemies; i++)
        {
            SpawnEnemy1(AllowedCo, spawnWidth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
    void SpawnEnemy1(Vector3 AllowedCo, float espacement)
    {
        int rand = Random.Range(0, 3);
        float randX;
        float randY;
        Vector3 spawnPosition;
        switch (rand)
      {
          case 1:
            //spawn a gauche

            randX = -1 * Random.Range(AllowedCo.x,AllowedCo.x + espacement);
            randY = -1* Random.Range(0, AllowedCo.y+espacement);
            spawnPosition = new Vector3(randX,randY,-1);
            break;
          case 2:
            //spawn a droite

            randX = Random.Range(AllowedCo.x,AllowedCo.x + espacement);
            randY = -1* Random.Range(0, AllowedCo.y+espacement);
            spawnPosition = new Vector3(randX,randY,-1);
            break;
          default:
            //spawn en bas

            randX = Random.Range(-1*AllowedCo.x-espacement,AllowedCo.x + espacement);
            randY = -1* Random.Range(AllowedCo.y, AllowedCo.y+espacement);
            spawnPosition = new Vector3(randX,randY,-1);
            break;
      }

        var direction = spawnPosition - transform.position ;
        direction.z = 0;

        //direction.Normalize();


        Rigidbody2D Enemy1 = Instantiate(enemy1, spawnPosition, transform.rotation);
        enemy1.AddForce(direction * enemySpeed);

    }
}
