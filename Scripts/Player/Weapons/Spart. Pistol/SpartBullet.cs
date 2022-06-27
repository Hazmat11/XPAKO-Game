using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartBullet : MonoBehaviour
{
    private int lifeTime = 100;
    private int tmp;

    void Update ()
    {
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject parent = GameObject.Find("Spart. Pistol");
            gameObject.transform.SetParent(parent.transform);
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
