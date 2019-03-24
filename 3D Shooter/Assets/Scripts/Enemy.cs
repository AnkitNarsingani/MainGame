using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : LivingEntity
{
    protected NavMeshAgent navMeshAgent;
    protected EnemyStates currentState;

    protected virtual void Start()
    {
        currentState = EnemyStates.Idle;
        healthBar = GetComponentInChildren<Slider>();
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
