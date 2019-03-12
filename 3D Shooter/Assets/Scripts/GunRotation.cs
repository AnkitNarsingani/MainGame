using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Rotate UI to Move

public class GunRotation : Gun
{
  
    Vector3 point;
    Vector3 originalPos;

   
    void Start()
    {
       
       
    }

    new void Update()
    {
            Look();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }


    new void Look()
    {
        #region PC
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
           
        }
        #endregion

        foreach (Touch t in Input.touches)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray touchRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
                if (Physics.Raycast(touchRay))
                    Shoot();
            }
        }
    }

    new void Shoot() { }
   
   


}
