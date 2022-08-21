using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AI : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
        IsShooting();
        tilt = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustHeight();
        Tilt();
        MoveHorizontal();
        CheckIfDead();
    }
}
