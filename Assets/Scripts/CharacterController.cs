using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [Header("Attributes")]
    public float moveMultiplier = 7f;
    public Rigidbody2D bulletR;
    public Rigidbody2D bulletB;

    public Animator animator;

    public Rigidbody2D enemy1;
    public SpriteRenderer[] lifes;
    public Sprite lifeLost;
    private int hearts = 5;
    private List<Rigidbody2D> bullets;

    GameManager manager = null;
    GameObject myPlatform = null;
    Vector3 oldPlatformPos;

    [SerializeField]
    public float bulletSpeed = 500f;
    public float lifespan = 1f;

    public float cooldown = 0.01f;

    public float NextFire = 0 ;
    public int nbEnemy = 1;

    void Start()
    {
        manager = GameManager.Instance;
        NextFire = Time.time;
        //audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time > NextFire + cooldown)
        {
           animator.SetTrigger("RightTrigger");
            FireR();
            NextFire = Time.time;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire + cooldown)
        {
            animator.SetTrigger("LeftTrigger");
            FireB();
            NextFire = Time.time;
        }
        if(nbEnemy > 0){
            SpawnEnemy1();
            nbEnemy--;
        }
    }



    void FireR()
    {
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
        Rigidbody2D ProjoR = Instantiate(bulletR, transform.position, transform.rotation);
        //bullets.Add(ProjoR);
        ProjoR.AddForce(direction * bulletSpeed);
        ProjoR.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoR.transform.gameObject, lifespan);
    }

    void FireB()
    {
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

        Rigidbody2D ProjoB = Instantiate(bulletB, transform.position, transform.rotation);
        //bullets.Add(ProjoB);
        ProjoB.AddForce(direction * bulletSpeed);
        ProjoB.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoB.transform.gameObject, lifespan);
    }


    void SpawnEnemy1()
    {
        Vector3 spawnPosition = new Vector3(-2.5f,0f,0f);
        var direction = spawnPosition - transform.position ;
        direction.z = 0;

        //direction.Normalize();

        Debug.Log(direction);

        Rigidbody2D Enemy1 = Instantiate(enemy1, spawnPosition, transform.rotation);
        enemy1.AddForce(direction * bulletSpeed);

    }



    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Monster" && hearts > 0)
        {
            lifes[hearts - 1].sprite = lifeLost;
            hearts--;
        }
    }
}
