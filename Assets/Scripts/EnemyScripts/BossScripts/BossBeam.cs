using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeam : Lifespan
{
    [SerializeField] private float wait;
    [SerializeField] private float speed;
    private bool ready;
    private void OnEnable()
    {
        transform.position = Vector3.zero;
        ready = false;
        StartCoroutine(Life());
        StartCoroutine(delay());
    }
    private void Update()
    {
        if (ready)
        {
            YeetLeft();
        }
    }

    private void YeetLeft() //ABSTRACTION
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(wait);
        ready = true;
    }
}
