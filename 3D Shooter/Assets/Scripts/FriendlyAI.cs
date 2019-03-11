using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : LivingEntity
{
    Queue<GameObject> enemies;
    private Transform currentEnemy;
    NavMeshAgent navMeshAgent;
    Vector3 initialPosition;

    void Start()
    {
        enemies = new Queue<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        Invoke("FindNextEnemy", 1);
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
            if(damageableObject != null)
            {
                hit.collider.GetComponent<LivingEntity>().Death += FindNextEnemy;
                damageableObject.TakeDamage(10);
            }
        }

        if (currentEnemy != null)
            transform.LookAt(currentEnemy);
    }

    public void RegisterEmemy(GameObject enemyGameObject)
    {
        enemies.Enqueue(enemyGameObject);
    }

    void FindNextEnemy()
    {
        if (enemies.Count > 0)
        {
            currentEnemy = enemies.Dequeue().transform;
        }
    }
}
