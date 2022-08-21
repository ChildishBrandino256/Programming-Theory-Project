using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AI : Enemy
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
        CheckIfDead();
    }
}
