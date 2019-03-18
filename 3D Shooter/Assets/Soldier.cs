using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {
    public GameObject prefab;
 
	void Start () {
      
        PoolManager.Instance.createPool(5, prefab);
	}
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            PoolManager.Instance.Reuse(prefab,Vector3.zero, Quaternion.identity);
        }
	}
}
