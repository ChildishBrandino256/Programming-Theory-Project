using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAboutAxis : MonoBehaviour //This just makes the missle spin.
{
    Vector3 axis = Vector3.up;
    float speed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, speed);
    }
}
