using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private SpawnManager spawnManager;
    float xRange = -10.5f;
    // Start is called before the first frame update
    void OnEnable()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
       transform.position = spawnManager.GenerateSpawnPos(false, xRange, 0);
    }
}
