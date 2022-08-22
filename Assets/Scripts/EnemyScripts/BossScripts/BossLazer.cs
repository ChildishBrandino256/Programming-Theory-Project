using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MoveH //INHERITANCE
{
    Vector3 startPos = new Vector3(1.5f, 0, 0);
    Vector3 direction;
    GameObject player;
    Vector3 playerInitialPos;
    float yRange = 10;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindTargetAndFire();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
        Bounds();
        VBounds();
    }

    void VBounds() //ABSTRACTION
    {
        if(-yRange > transform.position.y || transform.position.y > yRange)
        {
            gameObject.SetActive(false);
        }
    }

    void FindTargetAndFire() //ABSTRACTION
    {
        player = GameObject.Find("Player");
        if (player)
        {
            transform.position = startPos;
            playerInitialPos = player.transform.position;
            transform.LookAt(playerInitialPos);
            direction = startPos - playerInitialPos;
        }
    }
}
