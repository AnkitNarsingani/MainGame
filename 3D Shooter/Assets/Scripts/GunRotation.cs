using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotate UI to Move

public class GunRotation : Gun
{

    Vector3 point;
    Vector3 originalPos;

    public GameObject point_gameObject;
    private float h, v;
    private GunJoyStick gun_joyStick;
    public float lookSpeed = 1f;

    void Start()
    {
        gun_joyStick = FindObjectOfType<GunJoyStick>();
    }

    new void Update()
    {
        h = gun_joyStick.InputDirection.x;
        v = gun_joyStick.InputDirection.y;
        point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed*Time.deltaTime);
        
        Look();
      
    }

    new void Look()
    {
        #region PC
        Vector3 diff = point_gameObject.transform.position - transform.position;
        rot = Quaternion.LookRotation(-diff);
        transform.rotation = rot;
        #endregion
    }

    new void Shoot()
    {
         base.Shoot();
    }

   
}