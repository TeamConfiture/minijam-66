using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoudouBehavior : MonoBehaviour
{
    private SpriteRenderer sprd;
    private Rigidbody2D rb2d;
    private Collider2D coll2d;


    public GameObject player;
    public float distance = 1f;
    private float speed = 2f;
    private float knockback = -80f;

    public Rigidbody2D health;

    private List<Rigidbody2D> healthBar = new List<Rigidbody2D>();
    public float lifeYOffset = 1.5f;
    public float lifeXSpace = 1f;

    public int hp = 3;

    [Header("Audio")]
    private AudioSource audio;

    GameManager manager = null;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;

        sprd = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        coll2d = gameObject.GetComponent<Collider2D>();
        audio = gameObject.GetComponent<AudioSource>();



        this.addLifeRec(this.hp);
    }

    // Update is called once per frame
    void Update()
    {

           /* if (Vector3.Distance(player.transform.position, transform.position) > distance)
            {*/
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
           // }
    


    }

    public void addLifeRec(int hp)
    {
        this.hp = hp;
        float multiplier = 1-(float)hp;
        for(int i=0; i < hp; i++)
        {
            addlife(multiplier/2 * lifeXSpace);
            multiplier+=2;
        }
    }

    public void addlife(float xOffset)
    {
        Vector3 healthPosition = new Vector3(transform.position.x+ xOffset,transform.position.y + lifeYOffset,-1);
        Rigidbody2D Health = Instantiate(health, healthPosition,transform.rotation);
        Health.transform.parent = transform;
        Debug.Log(this.healthBar);
        Debug.Log(Health);
        this.healthBar.Add(Health);
        Debug.Log(this.healthBar);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Bullet")
        {
            if(this.hp > 1)
            {
                this.hp--;
                this.healthBar.ForEach(delegate(Rigidbody2D bar)
                {
                    Debug.Log("Sloubie1");
                    bar.transform.position = (new Vector2(bar.position.x + lifeXSpace/2,bar.position.y));
                    Debug.Log("Sloubie2");
                    });
                Destroy(this.healthBar[this.hp].gameObject);
                Destroy(this.healthBar[this.hp]);
                this.healthBar.RemoveAt(this.hp);
                
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        else if(collision.tag =="Player")
        {
            //Destroy(gameObject);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position  , knockback * speed * Time.deltaTime);
        }
    }

    private IEnumerator Transformation()
    {
        float animation = 0;

        while (animation < 1f)
        {
            yield return new WaitForSeconds(0.1f);
            animation += 0.1f;
            transform.localScale = transform.localScale - new Vector3(0.02f, 0.02f, 0.02f);
        }
        coll2d.isTrigger = true;
        Destroy(rb2d);
    }
}