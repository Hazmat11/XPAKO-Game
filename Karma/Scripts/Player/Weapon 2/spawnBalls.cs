using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] ballsPrefabs;
    public WeaponStats WS;

    List<GameObject> balls = new List<GameObject>();

    private int actualLevel;

    void Update()
    {
        levelUp();
    }

    void newBalls ()
    {
        int indexNB = selectBalls();

        for (int i = 0; i <= actualLevel -1; i++)
        {
            GameObject balls = Instantiate(ballsPrefabs[indexNB], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation, gameObject.transform);
        }
    }

    int selectBalls ()
    {
        //menu de selection de new ball

        // return #ballCode
        return 0;
    }

    void levelUp ()
    {
        if (actualLevel != WS.level)
        {
            actualLevel = WS.level;
            newBalls();
        }
    }
}