using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;
    List<GameObject> poolObjects = new List<GameObject>();
    public GameObject prefab;
    public int poolSize;
   


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

   public void createPool(GameObject prefab,int maxSize)
    {
      
        for (int i = 0; i < maxSize; i++)
        {
            Instantiate(prefab,transform);
            prefab.SetActive(false);
            poolObjects.Add(prefab);
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

    void Start()
    {
        createPool(prefab, poolSize);       
    }


    void Update()
    {

    }
}
