using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Enemy
{
    private bool track = false;
    private Collider hitbox;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPlayer();
        StartCoroutine(delay());
        tilt = 10f;
        transform.position = transform.parent.position;

        transform.rotation = Quaternion.identity;
        dead = false;
        track = false;
        bullet.SetActive(true);
        hitbox = GetComponent<BoxCollider>();
        hitbox.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            
            MoveHorizontal();
            if (track)
            {
                AdjustHeight();
                Lean();
            }
            
        }

    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        track = true;
    }

    void Lean()
    {
        //float zTilt = verticalInput * tilt; // might be negative, just test it
        //Vector3 euler = transform.localEulerAngles;
        // euler.z = Mathf.Lerp(euler.z, -zTilt, 2.0f);
        //transform.localEulerAngles = euler;
        float zRotation = -yDirection * tilt;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, zRotation), 0.5f) ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player Projectile"))
        {
            explosion.Play();
            dead = true;
            bullet.SetActive(false);
            StartCoroutine(Death());
            hitbox.enabled = false;
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(explosion.main.duration/2);
        gameObject.SetActive(false);
    }
}
