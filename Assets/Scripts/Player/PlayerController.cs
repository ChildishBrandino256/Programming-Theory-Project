using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Spaceship
{
    float speed;
    float baseSpeed = 8.0f;
    float dashSpeed = 14.0f;
    float fireRate = 0.35f;
    float shotOffset = 0.5f;
    bool hasPowerup;
    bool canShoot;
    Rigidbody playerRb;
    SpawnManager spawnManager;
    [SerializeField] TextMeshProUGUI gameOver;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        tilt = 30;
        playerRb = GetComponent<Rigidbody>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    // Update is called once per frame
    void Update()
    {
        InputProcessing();
        MovePlayer();
        Tilt();
        MovementConstrainV();
        MovementConstrainH();
        
        if (dead)
        {
            DeathState();
            CheckIfDead();
        }
        
    }
    void InputProcessing()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(ShootProjectile());
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = dashSpeed;
            tilt = 40;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = baseSpeed;
            tilt = 30;
        }
    }
    //Move the player
    void MovePlayer()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput, Space.World);
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput, Space.World);
    }
    
    //Define the moveable area for the player
    void MovementConstrainV()
    {
        float yRange = 6;
        //Top
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        //Bottom
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

    }

    void MovementConstrainH()
    {
        float xRange = -12;
        //Left
        if (transform.position.x < xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Right
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }

    void DeathState()
    {
        gameOver.gameObject.SetActive(true);
    }
    IEnumerator ShootProjectile()
    {
        canShoot = false;
        Vector3 shotOrigin = new Vector3(transform.position.x + shotOffset, transform.position.y, transform.position.z);
        GameObject bullet = BulletPooling.BulletPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shotOrigin;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    //Process collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
            hasPowerup = true;
            StartCoroutine(PowerupCountdown());
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            StopCoroutine(ShootProjectile());
            Instantiate(explosion, transform);
            spawnManager.gameOver = true;
            dead = true;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            StopCoroutine(ShootProjectile());
            spawnManager.gameOver = true;
            dead = true;
        }
    }
    

    IEnumerator PowerupCountdown()
    {
        if (hasPowerup)
        {
            fireRate /= 2;
            yield return new WaitForSeconds(5);
            fireRate *= 2;
            hasPowerup = false;
        }
    }
}
