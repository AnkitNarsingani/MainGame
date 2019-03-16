using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    Vector3 point;
    private LayerMask Ground;
    void Start ()
    {
        Ground = LayerMask.GetMask("Ground");
    }

	void Update ()
    {
        
        ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit,Mathf.Infinity,Ground))
        {
            {
                point = hit.point;
                transform.position = point;         
            }

        }
    }
}
