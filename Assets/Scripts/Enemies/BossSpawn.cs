using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float timeValue;
    public float Timefixed;
    public bool one = true;

    private Vector3 posSpawn;
    private int incZ;



    void Update()
    {
        if (timeValue >= 0f)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }
        else
        {
            timeValue = 0f;
        }

        if (Timefixed == 5 && one == true)
        {
            GameObject enemy = Instantiate(enemyPrefabs[0], posSpawn, transform.rotation);
            one = false;
        } 


    }
}
