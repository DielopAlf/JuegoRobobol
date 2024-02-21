using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   
    public int numberOfEnemies = 4;  
    public float spawnDelay = 1f;    

    public Transform spawnPoint;    

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    void SpawnEnemy()
    {
        if (numberOfEnemies > 0)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            numberOfEnemies--;
        }
        else
        {
           
            CancelInvoke("SpawnEnemy");
        }
    }
}
