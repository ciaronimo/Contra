using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    SpriteRenderer playerSprite;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform spawnPointUpRight;
    public Transform spawnPointUpLeft;
    public Transform spawnPointDownRight;
    public Transform spawnPointDownLeft;
    public Transform spawnPointProneRight;
    public Transform spawnPointProneLeft;
    public Transform spawnPointUp;
    public bool rapidFire;
    public bool spreadFire;


    public float projectileSpeed;
    public Projectile projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity Inspector Values Not Set");

        rapidFire = false;
        spreadFire = false;
        spawnPointUpRight.TransformDirection(Vector2.one * projectileSpeed);
        spawnPointUpLeft.TransformDirection(Vector2.one * -projectileSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (rapidFire == false)
        {
            if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                FireProjectile();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                FireProjectileUpDiagonalRight();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileUpDiagonalLeft();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                FireProjectileDownDiagonalRight();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileDownDiagonalLeft();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileUp();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                FireProjectileUp();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileProne();

            if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                FireProjectileProne();
        }

        else if (rapidFire == true)
        {
            if (Input.GetButton("Fire1") && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                FireProjectile();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                FireProjectileUpDiagonalRight();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileUpDiagonalLeft();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                FireProjectileDownDiagonalRight();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileDownDiagonalLeft();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileUp();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                FireProjectileUp();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                FireProjectileProne();

            if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                FireProjectileProne();
        }

            if (spreadFire == true)
            {
                if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                    SpreadFireProjectile();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                    SpreadFireProjectileUpDiagonalRight();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    SpreadFireProjectileUpDiagonalLeft();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                    SpreadFireProjectileDownDiagonalRight();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    SpreadFireProjectileDownDiagonalLeft();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    SpreadFireProjectileUp();

                if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                    SpreadFireProjectileUp();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    SpreadFireProjectileProne();

                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                    SpreadFireProjectileProne();

        }


        }

       
    void FireProjectile()
        {
            if (playerSprite.flipX)
            {
                Debug.Log("Fire Left Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);

                projectileInstance.speed = projectileSpeed;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), 0);
                

            }
            else
            {
                Debug.Log("Fire Right Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
                projectileInstance.speed = projectileSpeed;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        void FireProjectileUpDiagonalRight()
        {

            Debug.Log("Fire Up Right Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointUpRight.position, spawnPointUpRight.rotation);
            projectileInstance.speed = projectileSpeed;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, projectileSpeed);


            Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void FireProjectileUpDiagonalLeft()
        {

            Debug.Log("Fire Up Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointUpLeft.position, spawnPointUpLeft.rotation);
            projectileInstance.speed = projectileSpeed;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, projectileSpeed);

            Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void FireProjectileDownDiagonalRight()
        {

            Debug.Log("Fire Up Right Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointDownRight.position, spawnPointDownRight.rotation);
            projectileInstance.speed = projectileSpeed;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, -projectileSpeed);

            // Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void FireProjectileDownDiagonalLeft()
        {

            Debug.Log("Fire Up Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointDownLeft.position, spawnPointDownLeft.rotation);
            projectileInstance.speed = projectileSpeed;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, -projectileSpeed);

            Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        void FireProjectileUp()
        {

            Debug.Log("Fire Up Left Side");
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointUp.position, spawnPointUp.rotation);
            projectileInstance.speed = projectileSpeed;
            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void FireProjectileProne()
        {
            if (playerSprite.flipX)
            {
                Debug.Log("Fire Left Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointProneLeft.position, spawnPointProneLeft.rotation);

                projectileInstance.speed = projectileSpeed;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), 0);


            }
            else
            {
                Debug.Log("Fire Right Side");
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointProneRight.position, spawnPointProneRight.rotation);
                projectileInstance.speed = projectileSpeed;
                projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        void SpreadFireProjectile()
        {
            if (playerSprite.flipX)
            {
                Debug.Log("Fire Left Side");
                Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
                Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
                Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
                projectileInstance1.speed = projectileSpeed;
                projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), 0);
                projectileInstance2.speed = projectileSpeed;
                projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), (projectileSpeed * 0.25F));
                projectileInstance3.speed = projectileSpeed;
                projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), (projectileSpeed * -0.25F));



            }
            else
            {
                Debug.Log("Fire Right Side");
                Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
                Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
                Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
                projectileInstance1.speed = projectileSpeed;
                projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                projectileInstance2.speed = projectileSpeed;
                projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, (projectileSpeed * 0.25F));
                projectileInstance3.speed = projectileSpeed;
                projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, (projectileSpeed * -0.25F));
            }
        }

        void SpreadFireProjectileUpDiagonalRight()
        {

            Debug.Log("Fire Right Side");
            Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointUpRight.position, spawnPointUpRight.rotation);
            Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointUpRight.position, spawnPointUpRight.rotation);
            Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointUpRight.position, spawnPointUpRight.rotation);
            projectileInstance1.speed = projectileSpeed;
            projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, projectileSpeed);
            projectileInstance2.speed = projectileSpeed;
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * 0.75F), projectileSpeed * 1.25F);
            projectileInstance3.speed = projectileSpeed;
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * 1.25F), (projectileSpeed * 0.75F));
        }

        void SpreadFireProjectileUpDiagonalLeft()
        {

            Debug.Log("Fire Up Left Side");
            Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointUpLeft.position, spawnPointUpLeft.rotation);
            Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointUpLeft.position, spawnPointUpLeft.rotation);
            Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointUpLeft.position, spawnPointUpLeft.rotation);
            projectileInstance1.speed = projectileSpeed;
            projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), projectileSpeed);
            projectileInstance2.speed = projectileSpeed;
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -0.75F), projectileSpeed * 1.25F);
            projectileInstance3.speed = projectileSpeed;
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1.25F), (projectileSpeed * 0.75F));
        }

        void SpreadFireProjectileDownDiagonalRight()
        {

            Debug.Log("Fire Down Right Side");
            Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointDownRight.position, spawnPointDownRight.rotation);
            Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointDownRight.position, spawnPointDownRight.rotation);
            Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointDownRight.position, spawnPointDownRight.rotation);
            projectileInstance1.speed = projectileSpeed;
            projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, (projectileSpeed * -1));
            projectileInstance2.speed = projectileSpeed;
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * 0.75F), projectileSpeed * -1.25F);
            projectileInstance3.speed = projectileSpeed;
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * 1.25F), (projectileSpeed * -0.75F));
        }

        void SpreadFireProjectileDownDiagonalLeft()
        {

            Debug.Log("Fire Down Left Side");
            Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointDownLeft.position, spawnPointDownLeft.rotation);
            Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointDownLeft.position, spawnPointDownLeft.rotation);
            Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointDownLeft.position, spawnPointDownLeft.rotation);
            projectileInstance1.speed = projectileSpeed;
            projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), (projectileSpeed * -1));
            projectileInstance2.speed = projectileSpeed;
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -0.75F), projectileSpeed * -1.25F);
            projectileInstance3.speed = projectileSpeed;
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1.25F), (projectileSpeed * -0.75F));
        }


        void SpreadFireProjectileUp()
        {

            Debug.Log("Fire Up Left Side");
            Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointUp.position, spawnPointUp.rotation);
            Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointUp.position, spawnPointUp.rotation);
            Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointUp.position, spawnPointUp.rotation);
            projectileInstance1.speed = projectileSpeed;
            projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2((0), projectileSpeed);
            projectileInstance2.speed = projectileSpeed;
            projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -0.25F), projectileSpeed);
            projectileInstance3.speed = projectileSpeed;
            projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * 0.25F), projectileSpeed);
        }

        void SpreadFireProjectileProne()
        {
            if (playerSprite.flipX)
            {
                Debug.Log("Fire Left Side");
                Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointProneLeft.position, spawnPointProneLeft.rotation);
                Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointProneLeft.position, spawnPointProneLeft.rotation);
                Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointProneLeft.position, spawnPointProneLeft.rotation);
                projectileInstance1.speed = projectileSpeed;
                projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), 0);
                projectileInstance2.speed = projectileSpeed;
                projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), (projectileSpeed * 0.25F));
                projectileInstance3.speed = projectileSpeed;
                projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * -1), (projectileSpeed * -0.25F));



            }
            else
            {
                Debug.Log("Fire Right Side");
                Projectile projectileInstance1 = Instantiate(projectilePrefab, spawnPointProneRight.position, spawnPointProneRight.rotation);
                Projectile projectileInstance2 = Instantiate(projectilePrefab, spawnPointProneRight.position, spawnPointProneRight.rotation);
                Projectile projectileInstance3 = Instantiate(projectilePrefab, spawnPointProneRight.position, spawnPointProneRight.rotation);
                projectileInstance1.speed = projectileSpeed;
                projectileInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                projectileInstance2.speed = projectileSpeed;
                projectileInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, (projectileSpeed * 0.25F));
                projectileInstance3.speed = projectileSpeed;
                projectileInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, (projectileSpeed * -0.25F));
            }
        }
    

        public void StartRapidFire()
        {
            StartCoroutine(RapidFire());
        }

        IEnumerator RapidFire()
        {
            rapidFire = true;
            yield return new WaitForSeconds(3.0f);
            rapidFire = false;
        }

        public void StartSpreadFire()
        {
            StartCoroutine(SpreadFire());
        }

        IEnumerator SpreadFire()
        {
            spreadFire = true;
            yield return new WaitForSeconds(10.0f);
            spreadFire = false;
        }


    

}