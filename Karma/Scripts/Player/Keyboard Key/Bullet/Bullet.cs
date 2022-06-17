using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int lifeTime = 500;
    private int tmp;

    void Update ()
    {
        transform.Rotate(new Vector3(0f, 0f, 5) * Time.deltaTime);

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
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
