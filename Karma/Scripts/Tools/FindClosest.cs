using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour 
{
    public EnemyStats closestEnemy;

    void Update () {
        FindClosestEnemy ();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyStats closestEnemy = null;
        EnemyStats[] allEnemies = GameObject.FindObjectsOfType<EnemyStats>();


        foreach (EnemyStats currentEnemy in allEnemies) {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy) {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
    }
}
