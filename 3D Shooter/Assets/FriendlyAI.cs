using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : MonoBehaviour
{
    private Dictionary<float, GameObject> enemies;
    public float currentEnemyKey;
    NavMeshAgent navMeshAgent;
    Vector3 initialPosition;

    void Start()
    {
        enemies = new Dictionary<float, GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
    }

    void Update()
    {

    }

    public void RegisterEmemy(GameObject enemyGameObject)
    {
        enemies.Add(Vector3.Distance(transform.position, enemyGameObject.transform.position), enemyGameObject);
        StartCoroutine("WaitToFindEnemy");
    }

    void FindNextEnemy()
    {

        try
        {
            navMeshAgent.SetDestination(FindMinValue());
        }
        catch (KeyNotFoundException)
        {
            navMeshAgent.SetDestination(initialPosition);
        }
    }

    Vector3 FindMinValue()
    {
        currentEnemyKey = Mathf.Infinity;
        foreach (var enemy in enemies)
        {
            if (currentEnemyKey > enemy.Key)
            {
                currentEnemyKey = enemy.Key;
            }
        }

        return enemies[currentEnemyKey].transform.position;
    }

    private void RenameKey(float fromKey, float toKey)
    {
        GameObject value = enemies[fromKey];
        enemies.Remove(fromKey);
        enemies.Add(toKey, value);
    }

    IEnumerator WaitToFindEnemy()
    {
        yield return new WaitForSeconds(1f);

        FindNextEnemy();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.name.Equals("Quad"))
        {
            Destroy(other.gameObject);
            enemies.Remove(currentEnemyKey);
            for (int i = 0; i < enemies.Count; i++)
            {
                RenameKey(enemies.ElementAt(i).Key, Vector3.Distance(transform.position, enemies.ElementAt(i).Value.transform.position));
            }
            FindNextEnemy();
        }
    }
}
