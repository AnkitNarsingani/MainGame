﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : Enemy
{
    protected override void Start()
    {
        base.Start();

        friendlyAI.GetComponent<FriendlyAI>().RegisterEmemy(gameObject);
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(friendlyAI.transform.position);
        currentState = EnemyStates.Moving;
    }

    void Update()
    {
        if (currentState == EnemyStates.Moving)
            Move();
        else if (currentState == EnemyStates.Attacking)
            StartCoroutine("Attack");
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, friendlyAI.transform.position) < 3)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
            currentState = EnemyStates.Attacking;
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
