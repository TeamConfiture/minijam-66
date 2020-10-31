using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel0 : MonoBehaviour
{

    //public Rigidbody2D spawns ;
    public int nbWaveEnemies = 3;

    public int nbWave = 3;

    public int currentWave= 0;

    public int padding = 2;
    public Rigidbody2D enemy1;
    public float enemySpeed = 500f;

    public float spawnWidth = 1.4f;

    private Vector3 backgroundCo;
    private Vector3 AllowedCo;


    // Start is called before the first frame update
    void Start()
    {
        //Transform[] tab = spawns.GetComponentsInChildren<Transform>();
        // x <= abs(espacement + padding_x + background.width/2)
        // y < -background/2 - padding_y - espacement
        backgroundCo = GetComponent<Renderer>().bounds.size;
        AllowedCo = new Vector3(backgroundCo[0]/2 + padding, backgroundCo[1]/2 + padding, backgroundCo[2]);
        Global.remainingEnemies = this.nbWave * this.nbWaveEnemies;
        for(int i = 0; i < nbWaveEnemies; i++)
        {
            SpawnEnemy1(AllowedCo, spawnWidth);
        }
        currentWave++;
        Global.killedThisWave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.remainingEnemies==0)
        {
            Debug.Log("Victiore");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
            //soundEffect.Play();
        }
        else if(Global.killedThisWave && Global.remainingEnemies % nbWaveEnemies ==0)
        {
            Global.killedThisWave = false;
            Debug.Log("Oh no");
            Global.killedThisWave = false;
                for(int i = 0; i < nbWaveEnemies; i++)
            {
                SpawnEnemy1(AllowedCo, spawnWidth);
            }
        }

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
