
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Attributes")]
    public float moveMultiplier = 7f;
    public Rigidbody2D bulletR;
    public Rigidbody2D bulletB;

    public Rigidbody2D enemy1;

    


    GameManager manager = null;
    GameObject myPlatform = null;
    Vector3 oldPlatformPos;

    [SerializeField]
    public float bulletSpeed = 500f;
    public float lifespan = 1f;

    public float cooldown = 0.3f;
    public Sprite[] projectileAttackSprite;
    /*public float FireRate = 0.000003f;*/

    public float NextFire = 0 ;

    public int nbEnemy = 1;

    /*[Header("Audio")]
    public AudioClip lootCandy;
    public AudioClip shootCandy;
    public AudioClip deathClip;
    private AudioSource audio;*/

    void Start()
    {
        manager = GameManager.Instance;
        NextFire = Time.time;
        //manager.doudouNb = 0;
        //audio = transform.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time > NextFire + cooldown)
        {
            FireR();
            NextFire = Time.time;
            //NextFire = Time.time + FireRate;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire + cooldown)
        {
            FireB();
            NextFire = Time.time;
           // NextFire = Time.time + FireRate;
        }
        if(nbEnemy > 0){
            SpawnEnemy1();
            nbEnemy--;
        }
    }

    void FireR()
    {
        //Debug.Log("Fire");
        Debug.Log(Input.mousePosition);

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        var direction = worldMousePosition - transform.position;
        direction.z = 0;

        //on restreint le tir à 4 directions en enlevant la coordonée (x ou y) la plus petite (en valeur absolue) pour ne garder que la direction "principale"
       /* if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction.y = 0;
        else
            direction.x = 0;*/
            

       direction.Normalize();

        //Debug.Log(direction);
        //int projectileAttackRandomizer = 1;
        Rigidbody2D ProjoR = Instantiate(bulletR, transform.position, transform.rotation);
        ProjoR.AddForce(direction * bulletSpeed);
        ProjoR.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //ProjoR.GetComponent<SpriteRenderer>().sprite = projectileAttackSprite[projectileAttackRandomizer];
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoR.transform.gameObject, lifespan);
    }

    void FireB()
    {
        //Debug.Log("Fire");
        Debug.Log(Input.mousePosition);

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        var direction = worldMousePosition - transform.position;
        direction.z = 0;

        //on restreint le tir à 4 directions en enlevant la coordonée (x ou y) la plus petite (en valeur absolue) pour ne garder que la direction "principale"
       /* if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction.y = 0;
        else
            direction.x = 0;*/
            

       direction.Normalize();

        //Debug.Log(direction);
        //int projectileAttackRandomizer = 1;
        Rigidbody2D ProjoB = Instantiate(bulletB, transform.position, transform.rotation);
        ProjoB.AddForce(direction * bulletSpeed);
        ProjoB.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //ProjoR.GetComponent<SpriteRenderer>().sprite = projectileAttackSprite[projectileAttackRandomizer];
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoB.transform.gameObject, lifespan);
    }


    void SpawnEnemy1()
    {
        Debug.Log("Sloobie0");
        Vector3 spawnPosition = new Vector3(-2.5f,0f,0f);
        Debug.Log("Sloobie1");
        var direction = transform.position - spawnPosition;
        direction.z = 0;
        Debug.Log("Sloobie2");

        direction.Normalize();
        Debug.Log("Sloobie3");

        Rigidbody2D Enemy1 = Instantiate(enemy1, spawnPosition, transform.rotation);
        Debug.Log("Sloobie4");
        //enemy1.AddForce(direction * bulletSpeed);
        Debug.Log("Sloobie5");
        Enemy1.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Debug.Log("Sloobie6");

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Platform") {
            myPlatform = collision.gameObject;
            oldPlatformPos = myPlatform.transform.position;
            /*Debug.Log("Enter " + collision.gameObject);
            Debug.Log("Sticking to a Tile");*/
        } else if (collision.CompareTag("Candy"))
        {
            //audio.PlayOneShot(lootCandy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (myPlatform != null) {
            if (myPlatform == collision.gameObject) {
                myPlatform = null;
                //Debug.Log("Leaving my Tile");
            }
        }
    }
}
