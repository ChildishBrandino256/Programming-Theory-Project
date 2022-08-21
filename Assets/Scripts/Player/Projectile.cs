using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Weak Point"))
        {
            gameObject.SetActive(false);
        }
    }
}
