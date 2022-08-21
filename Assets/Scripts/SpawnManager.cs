using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private GameObject powerup;
    [SerializeField]
    private GameObject boss;

    float yRange = 5;

    float enemySpawnX = 14;
    float enemyStartDelay = 1.0f;
    float enemySpawnTime = 1;

    float powerupSpawnY = 7.5f;
    float powerupStartDelay = 15;
    float powerupSpawnTime = 20;

    int enemiesUntilBoss;

    public bool gameOver;

    bool timeForBoss;

    // Start is called before the first frame update
    void Awake()
    {
        enemiesUntilBoss = 5;
        timeForBoss = false;
        InvokeRepeating("SpawnRandomEnemy", enemyStartDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", powerupStartDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnRandomEnemy");
            CancelInvoke("SpawnPowerup");
        }
        if (timeForBoss)
        {
            CancelInvoke("SpawnRandomEnemy");
            boss.gameObject.SetActive(true);
            timeForBoss = false;
        }
    }

    void SpawnRandomEnemy()
    {
        if (enemiesUntilBoss > 0)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomIndex], GenerateSpawnPos(true, -yRange, yRange), enemies[randomIndex].gameObject.transform.rotation);
            enemiesUntilBoss--;
        }
        else
        {
            timeForBoss = true;
        }
    }

    void SpawnPowerup()
    {
        powerup.SetActive(true);
    }
    public Vector3 GenerateSpawnPos(bool isEnemy,float spawnRangeMin, float spawnRangeMax)
    {
        if (isEnemy == true)
        {
            float yPos = Random.Range(spawnRangeMin, spawnRangeMax);
            Vector3 spawnPos = new Vector3(enemySpawnX, yPos, 0);
            return spawnPos;
        }
        else
        {
            float xPos = Random.Range(spawnRangeMin, spawnRangeMax);
            Vector3 spawnPos = new Vector3(xPos, powerupSpawnY, 0);
            return spawnPos;
        }
    }
}
