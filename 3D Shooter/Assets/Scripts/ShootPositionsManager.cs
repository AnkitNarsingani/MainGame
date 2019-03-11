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
                point = shootPosition[i].position,
                isOccupied = false
            };
        }
    }

    void Start ()
    {

    }
	
	void Update ()
    {
		
	}

    public Vector3 GetShootPosition()
    {
        int temp = Random.Range(0, shootPoints.Length - 1);
        if (shootPoints[temp].isOccupied)
        {
            return GetShootPosition();
        }
        else
        {
            shootPoints[temp].isOccupied = true;
            return shootPoints[temp].point;
        }
    }

    public Vector3 ChangeShootPositions(Vector3 currentPosition)
    {
        int temp = 0;

        for (int i = 0; i < shootPoints.Length; i++)
        {
            if(shootPoints[i].point == currentPosition)
            {
                temp = i;
                continue;
            }
        }

        shootPoints[temp].isOccupied = false;
        return GetShootPosition();
    }
}

[System.Serializable]
public class PointInfo
{
    public Vector3 point;
    public bool isOccupied;
}
