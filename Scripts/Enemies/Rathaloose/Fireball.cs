using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage;
    public float speed;
    GameObject target;
    Rigidbody2D bulletRB;
    
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {  
        Player currentHealth = collision.collider.GetComponent<Player>();
        if (currentHealth != null)
        {
            currentHealth.TakeDamage(damage);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player currentHealth = other.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            currentHealth.TakeDamage(damage);
            Destroy(gameObject);
        }

        if(other.GetComponent<StatusEffects>() != null)
       {
        other.GetComponent<StatusEffects>().ApplyBurn(6);
       }
    }

}
