using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : LivingEntity
{
    protected NavMeshAgent navMeshAgent;
    protected float maxhealth;
    protected EnemyStates currentState;

    protected virtual void Start()
    {
        maxhealth = health;
        currentState = EnemyStates.Idle;
    }

    void Update()
    {

    }

    protected virtual IEnumerator Attack()
    {
        transform.LookAt(friendlyAI.transform);
        friendlyAI.GetComponent<IDamageable>().TakeDamage(attackPower);
        currentState = EnemyStates.Idle;
        yield return new WaitForSeconds(timeBetweenAttacks);
        if (friendlyAI.GetComponent<FriendlyAI>().GetCurrentState() == FriendlyAIStates.Attacking)
            StartCoroutine("Attack");
    }
}

public enum EnemyStates
{
    Idle,
    Moving,
    Attacking,
}
