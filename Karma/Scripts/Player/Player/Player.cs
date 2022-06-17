using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int SafeTime = 2000;
    public double PlayerSpeed = 50;

    private int damageTaken;
    private int tmpSafe;
    private int tmpGainLife;
    private int XPs;

    public GameObject gameManager;
    PlayerStatus PS;

    void Start ()
    {
        PS = gameManager.GetComponent<PlayerStatus>();
    }

    void Update()
    {
        if (damageTaken >= hp)
        {
            Death();
        }   
    }

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collisionInfo.gameObject.GetComponent<Collider2D>());
        }

        if (collisionInfo.gameObject.tag == "Bonus")
        {
            verifBonus(collisionInfo.gameObject);
        }

        if (collisionInfo.gameObject.tag == "Enemy")
        {
            TakeDamage(collisionInfo.gameObject);
        }

        if (collisionInfo.gameObject.tag == "XP")
        {
            TakeXP();
        }
    }

    void verifBonus (GameObject collision)
    {
        if (collision.name == "Speed+(Clone)")
        {
            PS.countS++;
            PS.UpBonusSpeed();
        }

        if (collision.name == "Damage+(Clone)")
        {
            PS.countD++;
        }

        if (collision.name == "SpeedWeapon+(Clone)")
        {
            PS.countSW++;
        }
    }

    void TakeDamage (GameObject enemy)
    {
        EnemyStats ES = enemy.GetComponent<EnemyStats>();
        damageTaken += ES.damage;
    }

    void TakeXP ()
    {
        XPs++;

        if (XPs == 20)
        {
            PS.level++;
            XPs = 0;
        }
    }

    void retrieveLife ()
    {
        if (damageTaken > 0)
        {
            if (tmpSafe == SafeTime)
            {
                if (tmpGainLife == 150)
                {
                    damageTaken--;
                    tmpGainLife = 0;
                    if (damageTaken == 0)
                    {
                        tmpSafe = 0;
                    }
                } else {
                    tmpGainLife++;
                }
            } else {
                tmpSafe++;
            }
        }
    }

    void Death ()
    {
        Destroy(gameObject);

        PS.dead = true;
    }
}
