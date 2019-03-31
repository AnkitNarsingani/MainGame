using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : LivingEntity
{
    List<GameObject> enemies;
    private Transform currentEnemy;
    NavMeshAgent navMeshAgent;
    private float timer = 0;
    FriendlyAIStates currentState;

    void Start()
    {
        maxhealth = health;
        friendlyAI = gameObject;
        enemies = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentState = FriendlyAIStates.Idle;
    }

    void Update()
    {
        ShootCurrentEnemy();   
    }

    private void ShootCurrentEnemy()
    {
        if (currentEnemy != null)
        {
            currentState = FriendlyAIStates.Attacking;
            currentEnemy.position = new Vector3(currentEnemy.position.x, transform.position.y, currentEnemy.position.z);
            transform.LookAt(currentEnemy);
        }
        else
        {
            FindNextEnemy();
        }
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && timer > timeBetweenAttacks)
        {
            timer = 0;
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(attackPower);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public override void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
            Die();   
    }

    public void Givehealth(float healthToGive)
    {
        health += healthToGive;
        healthBar.value = health;
    }

    protected override void Die()
    {
        currentState = FriendlyAIStates.Dead;
    }

    public FriendlyAIStates GetCurrentState()
    {
        return currentState;
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
                if (enemies[0] != null)
                {
                    currentEnemy = enemies[0].transform;
                }
                enemies.RemoveAt(0);
            }
        }
        catch (MissingReferenceException)
        {
            currentEnemy = enemies[0].transform;
            enemies.RemoveAt(0);
        }
    }
}

public enum FriendlyAIStates
{
    Idle,
    Attacking,
    Dead,
}
