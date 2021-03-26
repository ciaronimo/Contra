using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.x < player.transform.position.x)
    transform.position = Vector3.Lerp(transform.position, newPosition, 1); 

    }
}
