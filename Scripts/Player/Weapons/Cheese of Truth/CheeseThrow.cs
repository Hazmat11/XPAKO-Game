using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseThrow : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public WeaponStats WS;

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private int nbCheese = 1;
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;
    private GameObject parent;
    private float RandomAngle;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        Cam = GameObject.FindGameObjectsWithTag("MainCamera");
        FC = player[0].GetComponent<FindClosest>();
        parent = GameObject.Find("BulletsFolder");
        baseDamage = WS.damage;
    }

    void Update()
    {
        Aiming();
        ForShooting();
        LevelUp();
    }

    private void Aiming ()
    {
        RandomAngle = Random.Range(-15f, 15f);
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f + RandomAngle;
        rb.rotation = angle;
    }

    private IEnumerator ForShooting ()
    {
        if (tmp == WS.fireRate)
        {
            float time = 0;

            for (int i = 0; i < nbCheese; i++)
            {
                IsShooting();
                yield return new WaitForSeconds(time);
                if (time == 0)
                {
                    time += 0.05f;
                }
            }

            tmp = 0;
        } else {
            tmp++;
        }
        
    }

    private void IsShooting ()
    {
        GameObject cheese = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        cheese.transform.SetParent(parent.transform);
        Rigidbody2D rb = cheese.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            nbCheese = 1 + currentLevel;
            WS.damage = baseDamage + currentLevel;
        }
    }
}
