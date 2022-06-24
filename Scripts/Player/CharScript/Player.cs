using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public int level;
    public float currentHealth;
    public int killed;
    private float damage;

    public double PlayerSpeed = 50;

    public GameObject gameManager;
    public HealthBar healthBar;

    private DeathManage dm;
    private PlayerStatus PS;
    private DefineStatut ds;
    private ObjectEffect oe;

    void Awake()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
        oe = GameObject.FindObjectOfType<ObjectEffect>();
        LoadPlayer();
        dm = GameObject.FindObjectOfType<DeathManage>();
        maxHealth = ds.hp;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        PS = gameManager.GetComponent<PlayerStatus>();
    }

    public void Update()
    {
        killed = dm.deaths;
        healthBar.SetHealth(currentHealth);
        maxHealth = ds.hp;
    }

    void verifBonus(GameObject collision)
    {
        if (collision.name == "Speed+(Clone)")
        {
            PS.countS++;
            PS.UpBonusSpeed();
        }

        if (collision.name == "Damage+(Clone)")
        {
            PS.countD++;
        }

        if (collision.name == "SpeedWeapon+(Clone)")
        {
            PS.countSW++;
        }
    }

    void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        EnemyStats ES = collisionInfo.gameObject.GetComponent<EnemyStats>();

        if (collisionInfo.collider.CompareTag("Enemy") && currentHealth > 0)
        {
            TakeDamage(ES.damage);
            ES.hp -= (int)oe.epine;
            Debug.Log(oe.epine);
        }

        if (currentHealth == 0 || currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth + 1)
        {
            currentHealth = maxHealth;
        }
    }

    void TakeDamage(float damageEnemy)
    {
        damage = damageEnemy;
        damage -= ds.armor;
        Debug.Log(damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        currentHealth = data.health;
        killed = data.killed;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
