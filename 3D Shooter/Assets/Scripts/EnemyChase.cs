using System.Collections;
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
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, friendlyAI.transform.position) > 3)
        {
            navMeshAgent.SetDestination(friendlyAI.transform.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
