﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    RaycastHit hit;
    LayerMask Ground;
    Quaternion rot;
    Vector3 point;
    Vector3 originalPos;
    void Start()
    {
        Ground = LayerMask.GetMask("Ground");
        
    }


    void Update()
    {
        Look();
    }
    void Look()
    {
       

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Ground))
            {
            point = hit.point;
            point.y = 0;
            originalPos = transform.position - hit.point;
          
               rot= Quaternion.LookRotation(originalPos, Vector3.left);
               transform.rotation = rot;

        }

        
    }
}
