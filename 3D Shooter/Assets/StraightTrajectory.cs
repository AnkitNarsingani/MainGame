using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrajectory : MonoBehaviour {

    public GameObject finalPos;
    Rigidbody rb;
    LineRenderer lr;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();	
        lr = GetComponent<LineRenderer>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
       rb.velocity= Calculate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
		
	}

    Vector3 Calculate()
    {
        /*s=ut+1/2(at^2);
         * u=sxt;
         * v=u+at;
         * v^2-u^2=2as
         *s=distance in x;
         * t=time
         * a=gravity=0 in x component
         * 
         */
        Vector3 diff = finalPos.transform.position - transform.position;

        
        return diff;   
    }

    void Shoot()
    {
     
    }
    void Draw()
    {
        
    }
}
