using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

     PoolManager pm;
     GameObject prefab;
     int size;
	void Start ()
    {
       
        
    }
	
	
	void Update ()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("shoot");
            GameObject bullet = PoolManager.Instance.getPool();

            if (bullet == null) { return; }
            bullet.transform.position = transform.position + Vector3.forward * 3;  
            bullet.SetActive(true);
        }
      

    }
}
