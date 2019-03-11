using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrajectory : MonoBehaviour {

    public GameObject finalPos;
    Rigidbody rb;
    LineRenderer lr;
    Vector3 startPos;
    float h, k, x, y, a;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();	
        lr = GetComponent<LineRenderer>();
        //y=a\left(x-h\right)^2+k;
        //y=a(x-h)^2+k;
        //h=0;k=5;
        h = 0;
        k = 5;
        a = -1;

           
            startPos.z = 0;
          //  transform.position = startPos;
        

    }

    // Update is called once per frame
    void Update ()
    {
        //rb.velocity= Calculate();
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot();
        //}
        x++;
        y--;
        startPos.y = a * ((x - h) * (x - h)) + k;
        //x=rootOf(y-k/a) +h;
        startPos.x = Mathf.Sqrt((y - k) / a) + h;
        transform.position = startPos*Time.deltaTime/10;


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
