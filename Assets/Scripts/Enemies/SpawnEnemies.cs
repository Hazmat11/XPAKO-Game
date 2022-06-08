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
    public float timeValue;
    public bool spawn;
    public float Timefixed;

    private int tmp;
    private Vector3 posSpawn;
    private int incZ;

    void Update()
    {

         if (timeValue > 0)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }
        else
        {
            timeValue = 0;
        }

        if (randomPoints == true)
        {
            if (tmp == TimeForSpawn)
            {
                if (Timefixed >= 0 && spawn == true)
                {
                    int randEnemy = Random.Range(0, enemyPrefabs.Length);

                    for (int i = 0; i < group; i++)
                    {
                        int randPoints = Random.Range(0, spawnPoints.Length);
                        posSpawn = spawnPoints[randPoints].position;
                        posSpawn.z += incZ;

                        GameObject enemy = Instantiate(enemyPrefabs[0], posSpawn, transform.rotation);
                        incZ++;
                    }
                } if (Timefixed > 60){
                    spawn = false ;
                }

                if (randomEnemy == false)
                {
                    int randEnemy = Random.Range(0, enemyPrefabs.Length);

                    for (int i = 0; i < group; i++)
                    {
                        int randPoints = Random.Range(0, spawnPoints.Length);
                        posSpawn = spawnPoints[randPoints].position;
                        posSpawn.z += incZ;

                        GameObject enemy = Instantiate(enemyPrefabs[2], posSpawn, transform.rotation);
                        incZ++;
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
                    posSpawn = spawnPoints[i].position;
                    posSpawn.z += incZ;
                    Debug.Log(posSpawn.z);
                    
                    GameObject enemy = Instantiate(enemyPrefabs[0], posSpawn, transform.rotation);
                    incZ++;
                }

                tmp = 0;
            } else {
                tmp++;
            }
        }
    }
}
