using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : LivingEntity
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
}
