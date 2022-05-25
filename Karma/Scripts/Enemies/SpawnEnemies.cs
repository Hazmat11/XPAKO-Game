using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public bool randomPoints;
    public bool randomEnemy;
    public int group;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int TimeForSpawn;

    private int tmp;

    void Update()
    {
        if (randomPoints == true)
        {
            if (tmp == TimeForSpawn)
            {
                if (randomEnemy == true)
                {
                    int randEnemy = Random.Range(0, enemyPrefabs.Length);

                    for (int i = 0; i < group; i++)
                    {
                        int randPoints = Random.Range(0, spawnPoints.Length);
                        GameObject enemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randPoints].position, transform.rotation);
                    }
                } else {
                    for (int i = 0; i < group; i++)
                    {
                        int randPoints = Random.Range(0, spawnPoints.Length);
                        GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[randPoints].position, transform.rotation);
                    }
                }

                tmp = 0;
            } else {
                tmp++;
            }

        } else {
            if (tmp == TimeForSpawn)
            {
                int rangeSP = spawnPoints.Length;

                for (int i = 0; i < rangeSP ; i++)
                {
                    GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[i].position, transform.rotation);
                }

                tmp = 0;
            } else {
                tmp++;
            }
        }
    }
}
