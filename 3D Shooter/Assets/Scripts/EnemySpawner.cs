using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    [SerializeField] private Waves[] waves;
    private Waves currentWave;
    int waveCounter = 0;
    int enemiesToSpawn;
    float waveTimer;

    void Start()
    {
        StartNextWave();
    }

    void Update()
    {
        waveTimer += Time.deltaTime;
        if(enemiesToSpawn <= 0 && waveTimer > currentWave.timeBetweenWaves && waveCounter < waves.Length)
        {
            StartNextWave();
        }
        else if(enemiesToSpawn > 0)
        {
            GameObject g = Instantiate(currentWave.enemy, spawnPositions[Random.Range(0, 4)].position, Quaternion.identity);
            enemiesToSpawn--;
        }
    }

    void StartNextWave()
    {
        currentWave = waves[waveCounter];
        waveCounter++;
        enemiesToSpawn = currentWave.enemyCount;
    }
}

[System.Serializable]
class Waves
{
    public string name;
    public int enemyCount;
    public float timeBetweenWaves;
    public Transform[] shootPositions;
    public GameObject enemy;
}
