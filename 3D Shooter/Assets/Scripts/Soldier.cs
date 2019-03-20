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
        GameObject bullet = PoolManager.Instance.getPool();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("fd");
           
            if (bullet != null)
            {
                bullet.transform.position = transform.transform.position;
                bullet.transform.rotation = transform.transform.rotation;
                bullet.SetActive(true);
            }
        }
      

    }
}
