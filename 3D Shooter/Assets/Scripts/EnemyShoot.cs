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
        friendlyAI.GetComponent<FriendlyAI>().RegisterEmemy(gameObject);
        navMeshAgent = GetComponent<NavMeshAgent>();
        shootPositionScript = GameObject.Find("Shoot Positions").GetComponent<ShootPositionsManager>();
        navMeshAgent.SetDestination(shootPositionScript.GetShootPosition());
    }

    void Update()
    {

    }


    public override void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health < health / 2)
        {
            shootPositionScript.ChangeShootPositions(transform.position);
        }
        if (health <= 0)
        {
            Die();
        }  
    }
}
