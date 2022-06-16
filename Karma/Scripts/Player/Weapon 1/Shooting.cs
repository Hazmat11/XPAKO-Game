using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public GameObject player;
    public WeaponStats WS;

    private int tmp;
    private FindClosest FC;

    void Start ()
    {
        FC = player.GetComponent<FindClosest>();
    }

    void Update()
    {
        Aiming();
        Shoot();

        if(player == null)
        {
            Destroy(gameObject);
        }
    }

    void Aiming()
    {
        int nbFirePoints = firePoint.Length;

        for (int i = 0; i < nbFirePoints; i++)
        {
            Rigidbody2D rb = firePoint[i].GetComponent<Rigidbody2D>();
            Vector2 lookDir = FC.FindClosestEnemy().transform.position - firePoint[i].transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void Shoot()
    {
        if(tmp == WS.fireRate)
        {
            for (int i = 0; i < 3; i++)
            {
                int randPoints = Random.Range(0, firePoint.Length);
                GameObject bullet = Instantiate(bulletPrefab, firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
            }
            tmp = 0;
        } else {
            tmp++;
        }
    }
}