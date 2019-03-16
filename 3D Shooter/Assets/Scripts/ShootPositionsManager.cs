using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPositionsManager : MonoBehaviour
{
    [SerializeField] private Transform[] shootPosition;
    private PointInfo[] shootPoints;

    void Awake()
    {
        shootPoints = new PointInfo[shootPosition.Length];
        for (int i = 0; i < shootPosition.Length; i++)
        {
            shootPoints[i] = new PointInfo
            {
                index = i,
                point = shootPosition[i].position,
                isOccupied = false
            };
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public Vector3 GetShootPosition(EnemyShoot enemyShoot)
    {
        int temp = Random.Range(0, shootPoints.Length - 1);
        if (shootPoints[temp].isOccupied)
        {
            return GetShootPosition(enemyShoot);
        }
        else
        {
            enemyShoot.currentIndex = shootPoints[temp].index;
            shootPoints[temp].isOccupied = true;
            return shootPoints[temp].point;
        }
    }

    public Vector3 ChangeShootPositions(EnemyShoot enemyShoot)
    {
        int temp = 0;

        for (int i = 0; i < shootPoints.Length; i++)
        {
            if (shootPoints[i].index == enemyShoot.currentIndex)
            {
                temp = i;
                continue;
            }
        }

        shootPoints[temp].isOccupied = false;
        return GetShootPosition(enemyShoot);
    }

    public void ReleaseShootPositions(EnemyShoot enemyShoot)
    {
        int temp = 0;

        for (int i = 0; i < shootPoints.Length; i++)
        {
            if (shootPoints[i].index == enemyShoot.currentIndex)
            {
                temp = i;
                continue;
            }
        }
        shootPoints[temp].isOccupied = false;
    }
}

[System.Serializable]
public class PointInfo
{
    public int index;
    public Vector3 point;
    public bool isOccupied;
}
