using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float health;
    protected static GameObject friendlyAI;
    [SerializeField] protected float attackPower = 10;
    [SerializeField] protected float timeBetweenAttacks = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
