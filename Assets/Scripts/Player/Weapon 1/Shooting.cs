using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingN : MonoBehaviour
{
    public GameObject[] firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public GameObject player;

    List<GameObject> target = new List<GameObject>();

    private double fireSpeed;
    private double bulletForce;
    private int tmp;
    private int index = 0;
    public AudioSource audioSource;
    public AudioClip ShootSound;
    

    void Start()
    {
        WeaponStats WS = gameObject.GetComponent<WeaponStats>();
        fireSpeed = WS.fireRate;
        bulletForce = WS.bulletSpeed;
    }

    void Update()
    {
        SetTarget();
        if (target[index] != null)
        {
            Aiming();
            Shoot();
        }

        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player" || colliderInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), colliderInfo.gameObject.GetComponent<Collider2D>());
        }
        if (colliderInfo.gameObject.tag == "Enemy")
        {
            target.Add(colliderInfo.gameObject);
        }
    }

    int SetTarget()
    {
        while (target[index] == null)
        {
            index++;
        }
        return index;
    }

    void Aiming()
    {
        int nbFirePoints = firePoint.Length;

        for (int i = 0; i < nbFirePoints; i++)
        {
            Rigidbody2D rb = firePoint[i].GetComponent<Rigidbody2D>();
            Vector2 lookDir = target[index].transform.position - firePoint[i].transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void Shoot()
    {
        float BFtmp = (float)bulletForce;

        if (tmp == fireSpeed)
        {
            for (int i = 0; i < 2; i++)
            {
                int randPoints = Random.Range(0, firePoint.Length);
                GameObject bullet = Instantiate(
                    bulletPrefab,
                    firePoint[randPoints].transform.position,
                    firePoint[randPoints].transform.rotation
                );
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                AudioManager.instance.PlayClipAt(ShootSound, transform.position);
                rb.AddForce(firePoint[randPoints].transform.up * BFtmp, ForceMode2D.Impulse);
            }
            tmp = 0;
        }
        else
        {
            tmp++;
        }
    }
}
