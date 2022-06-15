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
}
