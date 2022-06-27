using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public int hp;
    public int damage;
    public GameObject xpPrefabs;
    private DeathManage dm;
    public DefineStatut ds;
    public AudioSource audioSource;
    public AudioClip DeathSound;

    void Awake()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
        dm = GameObject.FindObjectOfType<DeathManage>();
        damage = ds.countD;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Bullet")
        {
            hp -= damage;
            if (hp == 0 || hp < 0)
            {
                AudioManager.instance.PlayClipAt(DeathSound, transform.position);
                DropXP();
                Destroy(gameObject);
                dm.IncreaseDeaths();
            }
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
    }
}
