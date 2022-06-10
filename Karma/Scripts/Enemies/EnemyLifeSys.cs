using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public GameObject xpPrefabs;
    public EnemyStats ES;
    public double damageTaken;

    private int hp;


    void Update ()
    {
        hp = ES.hp;

        if (damageTaken >= hp)
            {
                DropXP();
                Destroy(gameObject);
            }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Bullet")
        {
            WeaponStats WS = collisionInfo.gameObject.GetComponent<WeaponStats>();
            damageTaken += WS.damage;
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
    }
}