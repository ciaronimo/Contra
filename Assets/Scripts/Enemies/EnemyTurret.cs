using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyTurret : MonoBehaviour
{
    public Transform projectileSpawnPointRight;
    public Transform projectileSpawnPointLeft;
    public Projectile projectilePrefab;
    SpriteRenderer sr;
    AudioSource explodeAudioSource;
   
    

    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;
    public AudioClip explodeSFX;

    Animator anim;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();


        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 turretTransform;
        Vector2 playerTransform;
        turretTransform = transform.position;
        playerTransform = player.position;
        
        if (Vector2.Distance(playerTransform, turretTransform) <= 10)
        {

            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                if (playerTransform.x >= turretTransform.x)
                {

                    // fireLeft = false;
                    
                    sr.flipX = true;
                   
                    Fire();
                    //anim.SetBool("Fire", true);
                    ;

                }
                else
                {
                    sr.flipX = false;
                  //  fireLeft = true;
                   // anim.SetBool("fireLeft", true);
                    Fire();
                   // anim.SetBool("Fire", true);


                }
                timeSinceLastFire = Time.time;
            }

        }




    }

    public void Fire()
    {
        if (sr.flipX)
        {
            
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            temp.speed = projectileForce;

            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileForce, projectileForce);
            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }
        else
        {

            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            temp.speed = -projectileForce;

            
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileForce, projectileForce);

            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            IsDead();
            Destroy(collision.gameObject);
          
        }
    }


    public void IsDead()
    {
        health--;
        if (health <= 0)
        {
            if (!explodeAudioSource)
            {
                explodeAudioSource = gameObject.AddComponent<AudioSource>();
                explodeAudioSource.clip = explodeSFX;
                explodeAudioSource.loop = false;
                explodeAudioSource.PlayOneShot(explodeSFX);
            }
            else
            {
                explodeAudioSource.PlayOneShot(explodeSFX);
            }

            anim.Play("Death");
 
        }
    }
    public void FinishedDeath()
    {
        Destroy(gameObject);
        GameManager.instance.score++;
    }



}



