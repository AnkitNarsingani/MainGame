using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : LivingEntity
{
    Queue<GameObject> enemies;
    private Rigidbody rb;
    private Transform currentEnemy;
    NavMeshAgent navMeshAgent;
    private float timer = 0;
    public float timeBetweenHits = 2;

    void Start()
    {
        friendlyAI = gameObject;
        enemies = new Queue<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
    }

    void Update()
    {
        ShootCurrentEnemy();

        if (currentEnemy != null)
        {
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
                damageableObject.TakeDamage(10);
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
