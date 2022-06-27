using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Player currentHealth = collision.collider.GetComponent<Player>();
        if (currentHealth != null)
        {
            currentHealth.TakeDamage(damage);
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
    }

}
