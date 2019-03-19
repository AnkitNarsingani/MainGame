using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : LivingEntity, IDamageable
{
    protected NavMeshAgent navMeshAgent;
    protected float maxhealth;

    protected virtual void Start()
    {
        maxhealth = health;
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
}
