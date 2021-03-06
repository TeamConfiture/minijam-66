﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoudouBehavior : MonoBehaviour
{
    private SpriteRenderer sprd;
    private Rigidbody2D rb2d;
    private Collider2D coll2d;


    public GameObject player;
    public float distance = 1f;
    public float speed = 2f;
    private float knockback = -80f;

    public Rigidbody2D health;

    private List<Rigidbody2D> healthBar = new List<Rigidbody2D>();
    public float lifeYOffset = 1.5f;
    public float lifeXSpace = 1f;

    public int hp;

    [Header("Audio")]
    public List<AudioClip> clip;

    GameManager manager = null;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;

        sprd = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        coll2d = gameObject.GetComponent<Collider2D>();
        //audio = gameObject.GetComponent<AudioSource>();
        player = GameObject.Find("Character");


        this.addLifeRec(this.hp);
    }

    // Update is called once per frame
    void Update()
    {

           /* if (Vector3.Distance(player.transform.position, transform.position) > distance)
            {*/
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
           // }
    


    }

    public void addLifeRec(int hp)
    {
        this.hp = hp;
        float multiplier = (float)hp -1;
        for(int i=0; i < hp; i++)
        {
            addlife(multiplier/2 * lifeXSpace);
            multiplier-=2;
        }
    }

    public void addlife(float xOffset)
    {
        Color bulletRed = new Color((float)0.81, (float) 0.29, (float) 0.33);
        Color bulletBlue = new Color((float) 0.3, (float) 0.32, (float) 0.81);
        Vector3 healthPosition = new Vector3(transform.position.x+ xOffset,transform.position.y + lifeYOffset,-2);
        Rigidbody2D Health = Instantiate(health, healthPosition,transform.rotation);
        Health.transform.parent = transform;
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            Health.GetComponent<SpriteRenderer>().color = bulletBlue;
            Health.gameObject.tag = "bulletBlue" ;
        }
        else
        {
            Health.GetComponent<SpriteRenderer>().color = bulletRed; ;
            Health.gameObject.tag = "bulletRed";
        }
        this.healthBar.Add(Health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag != "Monster" && collision.tag == this.healthBar[this.hp - 1].gameObject.tag)
        {
            if(this.hp > 1)
            {
                this.hp--;
                this.healthBar.ForEach(delegate(Rigidbody2D bar)
                {
                    bar.transform.position = (new Vector2(bar.position.x - lifeXSpace/2,bar.position.y));
                    });
                Destroy(this.healthBar[this.hp].gameObject);
                Destroy(this.healthBar[this.hp]);
                this.healthBar.RemoveAt(this.hp);
                Debug.Log("Vlan");
                
            }
            else
            {
                Destroy(gameObject);
                int musicNumber = Random.Range(0, clip.Count);
                               
                AudioSource.PlayClipAtPoint(clip[musicNumber],transform.position);
                if(!Global.killedThisWave)
                {
                    Global.killedThisWave = true;
                }
                Global.remainingEnemies--;
            }
            
        }
        else if(collision.tag =="Player")
        {
            //Destroy(gameObject);
            this.healthBar.ForEach(delegate(Rigidbody2D bar)
            {
              // To move correctly the healthbar when there is a collision between monster and witch
              bar.transform.position = new Vector3(bar.position.x,bar.position.y,-2);
            });
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position  , knockback * speed * Time.deltaTime);
            float multiplier = (float)hp -1;

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