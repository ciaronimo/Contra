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
    public bool isUpDiagonal;
    public bool isDownDiagonal;
    public bool isUp;
    public bool isProne;
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


        if (Input.GetButtonDown("Jump") && isGrounded && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            isProne = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            isProne = false;
        }

        if (GetComponent<PlayerFire>().rapidFire == true)
        {
            if (Input.GetButton("Fire1") && !Input.GetKey(KeyCode.W))
            {
                isFiring = true;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                isProne = false;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                isFiring = false;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))

            {
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }
            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
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
            
            if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.W))
            {
                
                isFiring = true;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                isProne = false;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                isFiring = false;
                isUpDiagonal = false;
                isDownDiagonal = false;
                isUp = false;
                
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                isUpDiagonal = true;
                isDownDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))

            {
                isDownDiagonal = true;
                isUpDiagonal = false;
                isUp = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                isUp = true;
                isDownDiagonal = false;
                isUpDiagonal = false;
                isFiring = false;
                isProne = false;
            }

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
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

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                isProne = true;
            }


        }



        if (playerSprite.flipX && horizontalInput > 0 || !playerSprite.flipX && horizontalInput < 0)
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
}
