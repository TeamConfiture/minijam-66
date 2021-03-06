﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController : MonoBehaviour
{
    [Header("Attributes")]
    public float moveMultiplier = 7f;
    public Rigidbody2D bulletR;
    public Rigidbody2D bulletB;

    public Animator animator;
    public AudioClip hit;

    public SpriteRenderer[] lifes;
    public Sprite lifeLost;
    private int hearts = 5;
    private List<Rigidbody2D> bullets;

    public Rigidbody2D health;


    GameManager manager = null;
    //GameObject myPlatform = null;
    //Vector3 oldPlatformPos;

    [SerializeField]
    public float bulletSpeed = 500f;
    public float lifespan = 1f;

    public float cooldown = 0.01f;

    public float NextFire = 0 ;
    
    public string GameOverScene;
    public AudioClip clip;
    void Start()
    {
        manager = GameManager.Instance;
        NextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time > NextFire + cooldown)
        {
           animator.SetTrigger("RightTrigger");
            Fire('R');
            NextFire = Time.time;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire + cooldown)
        {
            animator.SetTrigger("LeftTrigger");
            Fire('B');
            NextFire = Time.time;
        }
        
    }



    void Fire(char color)
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        var direction = worldMousePosition - transform.position;
        direction.z = 0;

        //on restreint le tir à 4 directions en enlevant la coordonée (x ou y) la plus petite (en valeur absolue) pour ne garder que la direction "principale"
       /* if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction.y = 0;
        else
            direction.x = 0;*/
        Rigidbody2D bullet;
        switch (color)
        {
          case ('R'):
            bullet = bulletR;
            break;
          case ('B'):
            bullet = bulletB;
            break;
          default:
            bullet = bulletR;
            break;
        }
        direction.Normalize();
        Rigidbody2D ProjoR = Instantiate(bullet, transform.position, transform.rotation);
        //bullets.Add(ProjoR);
        ProjoR.AddForce(direction * bulletSpeed);
        ProjoR.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoR.transform.gameObject, lifespan);
    }

/*    void FireB()
    {

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        var direction = worldMousePosition - transform.position;
        direction.z = 0;

        //on restreint le tir à 4 directions en enlevant la coordonée (x ou y) la plus petite (en valeur absolue) pour ne garder que la direction "principale"
       /* if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction.y = 0;
        else
            direction.x = 0;
            

       direction.Normalize();

        Rigidbody2D ProjoB = Instantiate(bulletB, transform.position, transform.rotation);
        //bullets.Add(ProjoB);
        ProjoB.AddForce(direction * bulletSpeed);
        ProjoB.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //audio.PlayOneShot(shootCandy);
        Destroy(ProjoB.transform.gameObject, lifespan);
    }
*/




    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Monster" && hearts > 0)
        {
            AudioSource.PlayClipAtPoint(hit,transform.position);
            lifes[hearts - 1].sprite = lifeLost;
            hearts--;
        }
        if (hearts == 0)
        {
            GameOver(GameOverScene,UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    private void GameOver(string scene, string currentScene)
    {   
        Reset.lastScene = currentScene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        //soundEffect.Play();
    }
}
