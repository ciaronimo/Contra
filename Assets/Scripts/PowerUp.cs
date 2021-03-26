using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum CollectibleType
    {
        RAPIDFIRE,
        SPREADFIRE,
        COLLECTIBLE
    }

    public CollectibleType currentCollectible;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player")
        {

            switch (currentCollectible)
            {
                case CollectibleType.RAPIDFIRE:
                    Destroy(gameObject);
                    coll.GetComponent<PlayerFire>().StartRapidFire();
                    Destroy(gameObject);
                    break;

                case CollectibleType.SPREADFIRE:
                    Destroy(gameObject);
                    coll.GetComponent<PlayerFire>().StartSpreadFire();
                    Destroy(gameObject);
                    break;
                case CollectibleType.COLLECTIBLE:
                    Destroy(gameObject);
                    GameManager.instance.lives++;

                    break;

            }

        }
        else if (coll.gameObject.layer == 6)
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}
