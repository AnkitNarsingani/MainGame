using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : Enemy
{
    ShootPositionsManager shootPositionScript;
    bool loaded = false;
    [HideInInspector] public int currentIndex;

    protected override void Start()
    {
        base.Start();
        friendlyAI.GetComponent<FriendlyAI>().RegisterEmemy(gameObject);
        navMeshAgent = GetComponent<NavMeshAgent>();
        shootPositionScript = GameObject.Find("Shoot Positions").GetComponent<ShootPositionsManager>();
        navMeshAgent.SetDestination(shootPositionScript.GetShootPosition(this));
        currentState = EnemyStates.Moving;
    }

    void Update()
    {
        if (currentState == EnemyStates.Moving)
            Moving();
        else if (currentState == EnemyStates.Attacking)
            StartCoroutine("Attack");
    }

    private void Moving()
    {
        float dist = navMeshAgent.remainingDistance;
        if (dist != Mathf.Infinity && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0)
        {
            navMeshAgent.ResetPath();
            currentState = EnemyStates.Attacking;
        }
    }

    public override void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if ((health / maxhealth) * 100 < 75 && !loaded)
        {
            loaded = true;
            Vector3 temp = shootPositionScript.ChangeShootPositions(this);
            navMeshAgent.SetDestination(temp);
            StartCoroutine("NavmeshUpdate");
        }
        if (health <= 0)
        {
            shootPositionScript.ReleaseShootPositions(currentIndex);
            Die();
        }
    }

    IEnumerator NavmeshUpdate()
    {
        yield return null;
        currentState = EnemyStates.Moving;
    }

    protected override void Die()
    {
        friendlyAI.GetComponent<FriendlyAI>().DeRegisterEmemy(gameObject);
        base.Die();
    }
}
