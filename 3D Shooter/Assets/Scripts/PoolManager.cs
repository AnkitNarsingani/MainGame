using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;
    public List<GameObject> poolObjects;
    public GameObject prefab;
    public int poolSize;

     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
      
    }

    public GameObject getPool()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
                return poolObjects[i];
        }
        return null;
    }
    private void createPool(GameObject g, int pSize)
    {
        for (int i = 0; i < pSize; i++)
        {

            g = Instantiate(prefab);
            g.SetActive(false);
            poolObjects.Add(g);
        }
    }

    void Start()
    {
        
        poolObjects = new List<GameObject>();
        createPool(prefab,14);
    }

   

    void Update()
    {

    }
}
