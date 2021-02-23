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

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public bool isFiring;
    public bool isCape;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

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
    /*
    public int lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (_lives < 0)
            {
                //run game over code here
            }

            Debug.Log("Current lives are " + lives);
        }
    }
    */


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


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;

        }

        if (playerSprite.flipX && horizontalInput > 0 || !playerSprite.flipX && horizontalInput < 0)
            playerSprite.flipX = !playerSprite.flipX;



        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFiring", isFiring);
    }
}
