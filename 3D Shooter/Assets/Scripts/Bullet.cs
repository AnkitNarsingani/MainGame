using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public GameObject explision;
    bool spawn = false;
    void Start ()
    {
        
	}
	
	
	void Update ()
    {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (spawn == false)
        {
            spawn = true;
            Instantiate(explision, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
          
        }

        
    }
   

   
}
