using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : LivingEntity
{
    Queue<GameObject> enemies;
    private Transform currentEnemy;
    NavMeshAgent navMeshAgent;
    private float timer = 0;
    public float timeBetweenHits = 2;
    float damageAmount = 10;

    void Start()
    {
        friendlyAI = gameObject;
        enemies = new Queue<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ShootCurrentEnemy();

        if (currentEnemy != null)
        {
            currentEnemy.position = new Vector3(currentEnemy.position.x, transform.position.y, currentEnemy.position.z);
            transform.LookAt(currentEnemy);
        }
        else
        {
            FindNextEnemy();
        }
    }

    private void ShootCurrentEnemy()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && timer > timeBetweenHits)
        {
            timer = 0;
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(damageAmount);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
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
