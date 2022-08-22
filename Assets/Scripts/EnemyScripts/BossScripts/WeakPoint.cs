using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    private Boss boss; //not quite inheritance, and i'm not sure if that would've been a more optimized way to do it

    private void Start()
    {
        boss = transform.parent.GetComponent<Boss>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Projectile"))
        {
            boss.TakeDamage();
        }
    }
}
