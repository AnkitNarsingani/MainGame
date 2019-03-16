using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : Enemy
{
    ShootPositionsManager shootPositionScript;
    bool loaded = false;
    public int currentIndex;
    protected override void Start()
    {
        base.Start();
        friendlyAI.GetComponent<FriendlyAI>().RegisterEmemy(gameObject);
        navMeshAgent = GetComponent<NavMeshAgent>();
        shootPositionScript = GameObject.Find("Shoot Positions").GetComponent<ShootPositionsManager>();
        navMeshAgent.SetDestination(shootPositionScript.GetShootPosition(this));
    }

    void Update()
    {
        float dist = navMeshAgent.remainingDistance;
        if (dist != Mathf.Infinity && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0 && navMeshAgent.isStopped)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
    }


    public override void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if ((health / maxhealth) * 100 < 75 && !loaded)
        {
            loaded = true;
            navMeshAgent.isStopped = false;
            Vector3 temp = shootPositionScript.ChangeShootPositions(this);
            navMeshAgent.SetDestination(temp);

        }
        if (health <= 0)
        {
            shootPositionScript.ReleaseShootPositions(this);
            Die();
        }  
    }
}
