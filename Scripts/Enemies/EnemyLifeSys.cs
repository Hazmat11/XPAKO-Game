using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public GameObject xpPrefabs;

    public EnemyStats ES;

    public double damageTaken;

    private int hp;

    void Update()
    {
        hp = ES.hp;

        if (damageTaken >= hp)
        {
            DropXP();
            DropItem();
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Bullet")
        {
            WeaponStats WS =
                collisionInfo
                    .gameObject
                    .transform
                    .parent
                    .GetComponent<WeaponStats>();
            damageTaken += WS.damage;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            WeaponStats WS =
                collision
                    .gameObject
                    .transform
                    .parent
                    .GetComponent<WeaponStats>();
            damageTaken += WS.damage;
        }
    }

    private void DropXP()
    {
        GameObject XP =
            Instantiate(xpPrefabs,
            gameObject.transform.position,
            transform.rotation);
    }

    private void DropItem()
    {
        if (Random.value > 0.9)
        {
            
        }
    }
}
