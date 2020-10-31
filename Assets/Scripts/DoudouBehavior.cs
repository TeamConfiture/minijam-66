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
    }

    // Update is called once per frame
    void Update()
    {

           /* if (Vector3.Distance(player.transform.position, transform.position) > distance)
            {*/
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
           // }
    


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Bullet turn evil doudou into nice ones <3
        
        if (collision.tag == "Bullet")
        {
            
            // Remove devil doudou and replace by cute doudou  
            /*isEvil = false;
            transform.gameObject.tag = "NiceDoudou";
            audio.PlayOneShot(transfo);
            StartCoroutine("Transformation");*/
            Destroy(gameObject);
            
            
        }else if(collision.tag =="Player"){
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
