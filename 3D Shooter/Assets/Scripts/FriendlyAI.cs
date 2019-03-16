using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : LivingEntity
{
    List<GameObject> enemies;
    private Transform currentEnemy;
    NavMeshAgent navMeshAgent;
    private float timer = 0;
    public float timeBetweenHits = 2;
    

    void Start()
    {
        friendlyAI = gameObject;
        enemies = new List<GameObject>();
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

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Die();
    }

    protected override void Die()
    {
        //Game Over
        Destroy(gameObject);
    }

    public void RegisterEmemy(GameObject enemyGameObject)
    {
        enemies.Add(enemyGameObject);
    }

    public void DeRegisterEmemy(GameObject enemyGameObject)
    {
        try
        {
            enemies.Remove(enemyGameObject);
        }
        catch(MissingReferenceException)
        {

        }
    }

    void FindNextEnemy()
    {
        try
        {
            if (enemies.Count > 0)
            {
                currentEnemy = enemies[0].transform;
                enemies.RemoveAt(0);
            }
        }
        catch (MissingReferenceException)
        {

        }
    }
}
