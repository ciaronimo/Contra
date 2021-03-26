using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class EnemyGunner : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    AudioSource deathAudioSource;


    public Transform projectileSpawnPointRight;
    public Transform projectileSpawnPointLeft;
    public Projectile projectilePrefab;
    public Transform player;

    public float projectileForce;
    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public AudioClip deathSFX;

    public int health;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


       
        if (health <= 0)
        {
            health = 3;
        }

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 gunnerTransform;
        Vector2 playerTransform;
        gunnerTransform = transform.position;
        playerTransform = player.position;

    

       

        if (Vector2.Distance(playerTransform, gunnerTransform) <= 15)
        {
            anim.SetBool("isIdle", false);
            if (Vector2.Distance(playerTransform, gunnerTransform) >= 5)
            {
                speed = 3.0f;
            }
            else
            {
                anim.SetBool("isIdle", true);
                speed = 0;
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    Fire();
                    timeSinceLastFire = Time.time;
                }
            }

            if (playerTransform.x >= gunnerTransform.x)
            {
                sr.flipX = false;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                sr.flipX = true;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            };


        
 

        }
        else
        {
            speed = 0;
            anim.SetBool("isIdle", true);
        }
    }

        public void Fire()
    {
        if (sr.flipX)
        {
            anim.SetTrigger("isFiring");
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            temp.speed = -projectileForce;

            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileForce, 0);
            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }
        else
        {
            anim.SetTrigger("isFiring");
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            temp.speed = projectileForce;


            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileForce, 0);

            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

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
            rb.velocity = Vector2.zero;
            anim.Play("GunnerDeath");
            if (!deathAudioSource)
            {
                deathAudioSource = gameObject.AddComponent<AudioSource>();
                deathAudioSource.clip = deathSFX;
                deathAudioSource.loop = false;
                deathAudioSource.PlayOneShot(deathSFX);
            }
            else
            {
                deathAudioSource.PlayOneShot(deathSFX);
            }


        }
    }

    public void IsSquished()
    {
        anim.SetBool("Squish", true);
    }

    public void FinishedDeath()
    {
        Destroy(gameObject);
        GameManager.instance.score++;
    }

}
