using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public EnemyStats ES;
    public bool burn;
    public bool slow;

    public float coefSlow;
    public int damageBurn;

    void Update ()
    {
        if (burn)
        {
            Burn();
        }

        if (slow)
        {
            Slowed();
        }
    }

    void Burn ()
    {
        int tmp = 0;
        int rate = 100;

        int tmpBis = 0;
        int time = 5;

        while (tmpBis <= time)
        {
            if (tmp == rate)
            {
                ES.hp -= damageBurn;

                tmp = 0;
                tmpBis++;
            } else {
                tmp++;
            }
        }

        tmpBis = 0;
    }

    void Slowed ()
    {
        int tmp = 0;
        int time = 250;

        int normalSpeed = ES.speed;

        ES.speed = (int)(ES.speed * coefSlow);

        while (slow == true)
        {
            tmp++;

            if (tmp == time)
            {
                slow = false;
            }
        }

        ES.speed = normalSpeed;
    }
}
