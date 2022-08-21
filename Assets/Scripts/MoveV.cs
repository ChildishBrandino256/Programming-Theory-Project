using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveV : MonoBehaviour
{
    public float speed;
    float yBound = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        float yPosition = transform.position.y;
        if (yPosition < -yBound || yPosition > yBound)
        {
            gameObject.SetActive(false);
        }
    }
}
