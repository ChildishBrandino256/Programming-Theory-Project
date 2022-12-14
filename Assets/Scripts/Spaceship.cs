using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour //This script is a parent to both the player and enemies due to some shared functionality between the two classes. INHERITANCE
{
    protected bool dead;
    [SerializeField] protected float tilt = 20.0f;
    protected float horizontalInput;
    protected float verticalInput;

    [SerializeField] protected bool destroy;
    [SerializeField]
    protected ParticleSystem explosion;

    protected virtual void CheckIfDead()
    {
        Vector3 location = transform.position;
        explosion = Instantiate(explosion, location, explosion.transform.rotation);
        explosion.Play();
        if (destroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    protected void Tilt()
    {
        float xTilt = verticalInput * tilt; // might be negative, just test it
        Vector3 euler = transform.localEulerAngles;
        euler.x = Mathf.Lerp(euler.x, xTilt, 2.0f);
        transform.localEulerAngles = euler;
    }
}
