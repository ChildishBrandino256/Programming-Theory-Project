using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    private Quaternion targetRotation;

    private void Start()
    {
        InvokeRepeating("GetRandomRotation", 0, 1);
    }
    void Update()
    {
        Rotate();
        
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime /2);
    }
    void GetRandomRotation()
    {
        targetRotation = Quaternion.Euler(Random.Range(-1f, 1f), Random.Range(-91f, -88f), Random.Range(88f, 92f));
    }
}
