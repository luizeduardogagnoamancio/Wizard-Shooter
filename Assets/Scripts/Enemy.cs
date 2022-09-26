using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public int maxHealth;

    private GameObject playerAll;

    [HideInInspector]
    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    public int damage;

    public HealthBarBehaviour healthBar;

    public float expGive = 100;


    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAll = GameObject.FindGameObjectWithTag("Player");
        healthBar.SetHealth(health, maxHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.SetHealth(health, maxHealth);

        if (health <= 0)
        {
            playerAll.GetComponent<Player>().GainExp(expGive);
            Destroy(gameObject);

        }
    }
}
