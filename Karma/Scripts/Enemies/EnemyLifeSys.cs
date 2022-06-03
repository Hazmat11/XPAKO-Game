using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public int hp = 3;
    public DeathManager dm;
    public GameObject xpPrefabs;

    private double damage;

    void Awake()
    {
        dm = GameObject.FindObjectOfType<DeathManager>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Bullet")
        {
            // GameObject bullet = collisionInfo.gameObject.transform.parent.gameObject;
            // WeaponStats WS = bullet.GetComponent<WeaponStats>();
            // damage += WS.damage;
            // Debug.Log("ui : " + damage);

            damage++;

            if (damage == hp)
            {
                DropXP();
                dm.IncreaseDeath();
                Destroy(gameObject);
            }
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
    }
}