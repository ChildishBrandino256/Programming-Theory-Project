using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AI : Enemy //INHERITANCE, POLYMORPHISM, and ABSTRACTION entirely
{
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustHeight();
        Tilt();
        MoveHorizontal();
        if (dead)
        {
            CheckIfDead();
        }
    }
}
