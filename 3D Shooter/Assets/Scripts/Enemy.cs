using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : LivingEntity
{
    protected GameObject friendlyAI;
    protected NavMeshAgent navMeshAgent;

    protected virtual void Start()
    {
        friendlyAI = FindObjectOfType<FriendlyAI>().gameObject;
    }

    void Update()
    {

    }
}
