using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public bool isTouching;
    public float playerCheckRadius;
    public LayerMask isTouchingPlayer;

   void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("touching");
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
            {
                effector.rotationalOffset = 180f;
            }
        }
    }
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }

 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.S))
        {
            effector.rotationalOffset = 0;
        }


    }
 
}
