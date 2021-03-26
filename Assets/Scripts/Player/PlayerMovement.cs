using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer playerSprite;
    AudioSource jumpAudioSource;
    AudioSource fireAudioSource;
    AudioSource deathAudioSource;




    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public bool isFiring;
    public bool isUpDiagonal;
    public bool isDownDiagonal;
    public bool isUp;
    public bool isProne;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public AudioClip jumpSFX;
    public AudioClip fireSFX;
    public AudioClip deathSFX;


    int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Current Score is " + _score);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 100;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please set a transform value for groundcheck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);


        if (Input.GetButtonDown("Jump") && isGrounded && !Input.GetKey(KeyCode.S) && Time.timeScale == 1)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            if (!jumpAudioSource)
            {
                jumpAudioSource = gameObject.AddComponent<AudioSource>();
                jumpAudioSource.clip = jumpSFX;
                jumpAudioSource.loop = false;
                jumpAudioSource.Play();
            }
            else
            {
                jumpAudioSource.Play();
            }

        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && Time.timeScale == 1)
        {
            isProne = true;
        }

        if (Input.GetKeyUp(KeyCode.S) && Time.timeScale == 1)
        {
            isProne = false;
        }

        if (GetComponent<PlayerFire>().rapidFire == true && Time.timeScale == 1)
        {
      
            if (Input.GetButton("Fire1") && !Input.GetKey(KeyCode.W))
            {
                fireSound();
                isFiring = true;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                isProne = false;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                fireSound();
                isFiring = false;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                fireSound();
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                fireSound();
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                fireSound();
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))

            {
                fireSound();
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }
            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                fireSound();
                isUp = true;
                isDownDiagonal = false;
                isUpDiagonal = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                isProne = true;
            }
        }
        else 
        {
            

            if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.W) && Time.timeScale == 1)
            {
                fireSound();
                isFiring = true;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                isProne = false;
            }

            if (Input.GetButtonUp("Fire1") && Time.timeScale == 1)
            {
                
                isFiring = false;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Time.timeScale == 1)
            {
                fireSound();
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Time.timeScale == 1)
            {
                fireSound();
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Time.timeScale == 1)
            {
                fireSound();
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Time.timeScale == 1)

            {
                fireSound();
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Time.timeScale == 1)
            {
                fireSound();
                isUp = true;
                isDownDiagonal = false;
                isUpDiagonal = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Time.timeScale == 1)
            {
                fireSound();
                isUp = true;
                isDownDiagonal = false;
                isUpDiagonal = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && Time.timeScale == 1)
            {
                isProne = true;
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && Time.timeScale == 1)
            {
                isProne = true;
            }


        }



        if (playerSprite.flipX && horizontalInput > 0 || !playerSprite.flipX && horizontalInput < 0 && Time.timeScale == 1)
            playerSprite.flipX = !playerSprite.flipX;



        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFiring", isFiring);
        anim.SetBool("isUpDiagonal", isUpDiagonal);
        anim.SetBool("isDownDiagonal", isDownDiagonal);
        anim.SetBool("isUp", isUp);
        anim.SetBool("isProne", isProne);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyProjectile")
        {
            GameManager.instance.health--;
            Destroy(collision.gameObject);

            if (GameManager.instance.health <= 0)
            {
                if (!deathAudioSource)
                {
                    deathAudioSource = gameObject.AddComponent<AudioSource>();
                    deathAudioSource.clip = deathSFX;
                    deathAudioSource.loop = false;
                    deathAudioSource.Play();
                }
                else
                {
                    deathAudioSource.Play();
                }

                anim.Play("PlayerDeath");

            }
        }

       
    }

    private void fireSound()
    {
        if (!fireAudioSource)
        {
            fireAudioSource = gameObject.AddComponent<AudioSource>();
            fireAudioSource.clip = fireSFX;
            fireAudioSource.loop = false;
            fireAudioSource.Play();
        }
        else
        {
            fireAudioSource.Play();
        }

    }

    private void finishedDeath()
    {
        Destroy(gameObject);
        GameManager.instance.lives--;
        GameManager.instance.health = GameManager.instance.maxHealth;
    }


}
