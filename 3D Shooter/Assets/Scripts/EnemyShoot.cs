using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : Enemy
{
    ShootPositionsManager shootPositionScript;
    protected override void Start()
    {
        base.Start();
        navMeshAgent = GetComponent<NavMeshAgent>();
        shootPositionScript = GameObject.Find("Shoot Positions").GetComponent<ShootPositionsManager>();
        navMeshAgent.SetDestination(shootPositionScript.GetShootPosition());
    }

    void Update()
    {

    }

    protected override void Die()
    {

    }
}
