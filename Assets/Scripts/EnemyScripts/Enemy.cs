using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship
{
    protected bool shoots;
    protected bool followPlayer;

    protected GameObject player;
    [SerializeField] protected GameObject bullet;
    PlayerController playerscript;

    protected Vector3 playerPos;

    protected float xBound = 16;
    [SerializeField] float vSpeed = 1;
    float shotDelay;
    [SerializeField] float fireRate = 1;
    [SerializeField] protected float hSpeed;
    
    protected float yDirection;
    protected Vector3 yMovement;
    protected Vector3 xMovement;


    protected void IsShooting()
    {
        shotDelay = Random.Range(0.5f, 1.5f);
        InvokeRepeating(nameof(Shoot), shotDelay, fireRate);
    }
    protected void FindPlayer()
    {
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<PlayerController>();
    }
    protected void Shoot()
    {
        if (player)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }
    protected virtual void AdjustHeight()
    {
        if (player)
        {
            playerPos = player.transform.position;
            yDirection = playerPos.y - transform.position.y;
            yMovement = Time.deltaTime * vSpeed * yDirection * Vector3.up;
            transform.Translate(yMovement,Space.World);
            verticalInput = Mathf.Clamp(yDirection, -1, 1);
        }
    }
    protected void MoveHorizontal()
    {
        xMovement = hSpeed * Time.deltaTime * Vector3.right;
        transform.Translate(xMovement);
        float xPosition = transform.position.x;

        if (xPosition < -xBound || xPosition > xBound)
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player Projectile"))
        {
            dead = true;
            playerscript.score++;
        }
    }
}
