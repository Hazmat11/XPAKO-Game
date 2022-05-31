using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    private GameObject player;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    Renderer rend;
    Color c;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player = GameObject.Find("Player");
        rend = GetComponent<Renderer>();
        c = rend.material.color;

    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.collider.CompareTag("Enemy") && currentHealth > 0)
            StartCoroutine("GetInvulnerable");
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }     

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision (6, 7, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds (1f);
        Physics2D.IgnoreLayerCollision (6, 7, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
