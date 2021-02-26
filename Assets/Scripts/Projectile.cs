using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }


        Destroy(gameObject, lifetime);

    }
    void OnEnable()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("ground");
        foreach (GameObject ground in platforms)
        {
            Physics2D.IgnoreCollision(ground.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }



    }


}