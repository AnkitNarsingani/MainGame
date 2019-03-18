using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

   public static PoolManager Instance;
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    internal void createPool(int v, object prefab)
    {
        throw new NotImplementedException();
    }

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
   
   
    public void createPool(int size,GameObject prefab)
    {
        int poolKey = prefab.GetInstanceID();
        if(!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
            for (int i = 0; i < size; i++)
            {
                var spawnedGameObject = Instantiate(prefab) as GameObject;
                spawnedGameObject.SetActive(false);
                poolDictionary[poolKey].Enqueue(spawnedGameObject);
            }
        }
    }

    public void Reuse(GameObject g, Vector3 v, Quaternion q)
    {
        int poolKey = g.GetInstanceID();
      if(poolDictionary[poolKey].Contains(g))
        {
            GameObject reuseGameObject = poolDictionary[poolKey].Dequeue();

            poolDictionary[poolKey].Enqueue(reuseGameObject);
            reuseGameObject.SetActive(true);
            reuseGameObject.transform.position = v;
            reuseGameObject.transform.rotation = q;
          
        }
    }
    void Start ()
    {
		
	}
	

	void Update () {
		
	}
}
