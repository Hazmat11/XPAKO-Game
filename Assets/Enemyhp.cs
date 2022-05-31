using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp : MonoBehaviour
{

    private GameObject enemy;

    public int maxHealth = 20;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Zombie 1");
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D other)
    {
        TakeDamage(0);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
