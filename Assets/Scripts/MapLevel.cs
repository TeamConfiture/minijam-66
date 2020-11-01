using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : MonoBehaviour
{

    //public Rigidbody2D spawns ;
    public int nbWaveEnemies;
    public int maxrand;
    public int nbWave ;

    public AudioClip clip;
    public AudioSource music;

    // valeur entre 0 et 1
    public float musicVolume = 0.2f;
    public string LoadScene;
    public int currentWave;
    public GameObject player;
    public int padding = 2;
    public List<Rigidbody2D> enemies;
    public int SqueletProbability;
    public float enemySpeed = 500f;

    public float spawnWidth = 1.4f;

    protected Vector3 backgroundCo;
    protected Vector3 AllowedCo;

    protected float[,] parameters; 
    
    // Start is called before the first frame update

    protected void BeginStart()
    {
        music.loop = true;
        music.clip = clip;
        music.volume = musicVolume;
        music.Play();
        backgroundCo = GetComponent<Renderer>().bounds.size;
        AllowedCo = new Vector3(backgroundCo[0]/2 + padding, backgroundCo[1]/2 + padding, backgroundCo[2]);
    }
    protected void EndStart()
    {
        //Transform[] tab = spawns.GetComponentsInChildren<Transform>();
        // x <= abs(espacement + padding_x + background.width/2)
        // y < -background/2 - padding_y - espacement
        Global.remainingEnemies = this.nbWave * this.nbWaveEnemies;
        for(int i = 0; i < nbWaveEnemies; i++)
        {
            SpawnEnemy1();
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(LoadScene);
            //soundEffect.Play();
        }
        else if(Global.killedThisWave && Global.remainingEnemies % nbWaveEnemies ==0)
        {
            Global.killedThisWave = false;
            Debug.Log("Oh no");
            Global.killedThisWave = false;
                for(int i = 0; i < nbWaveEnemies; i++)
            {
                SpawnEnemy1();
            }
        }

    }
    void SpawnEnemy1()
    {
        int rand = Random.Range(0, maxrand);
        float randX;
        float randY;
        Vector3 spawnPosition;
        switch (rand)
        {
          case 1:
            //spawn a gauche

            randX = -1 * Random.Range(parameters[0,0],parameters[0,1]);
            randY = -1* Random.Range(parameters[0,2], parameters[0,3]);
            break;
          case 2:
            //spawn a droite
            randX = Random.Range(parameters[0,0],parameters[0,1]);
            randY = -1* Random.Range(parameters[0,2], parameters[0,3]);
            break;
          case 3:
            //spawn en haut
            randX = Random.Range(parameters[1,0],parameters[1,1]);
            randY = Random.Range(parameters[1,2], parameters[1,3]);
            break;
          default:
            //spawn en bas

            randX = Random.Range(parameters[1,0],parameters[1,1]);
            randY = -1* Random.Range(parameters[1,2], parameters[1,3]);
            break;
        }
        spawnPosition = new Vector3(randX,randY,-1);
        var direction = spawnPosition - player.transform.position ;
        direction.z = 0;

        //direction.Normalize();

        int toSpawn = Random.Range(0, 100);
        if (toSpawn < SqueletProbability)
        {
            toSpawn = 1;
        }
        else
        {
            toSpawn = 0;
        }
        Rigidbody2D Enemy1 = Instantiate(enemies[toSpawn], spawnPosition, transform.rotation);
        enemies[toSpawn].AddForce(direction * enemySpeed);

    }
}
