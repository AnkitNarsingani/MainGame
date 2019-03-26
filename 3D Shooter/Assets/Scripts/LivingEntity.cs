using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float health;
    protected float maxhealth;
    protected static GameObject friendlyAI;
    [SerializeField] protected float attackPower = 10;
    [SerializeField] protected float timeBetweenAttacks = 1;
    [SerializeField] protected Slider healthBar;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
