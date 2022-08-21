using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public float speed;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}