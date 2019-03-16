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
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls = Instantiate(lockSprite, point, sprite_opp);
    }

    new void Update()
    {
        h = gun_joyStick.Horizontal();
        v = gun_joyStick.Vertical();
       
        if(v<=0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, 0, -2*v) * lookSpeed * Time.deltaTime);
        }else if (v >= 0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed * Time.deltaTime);
        }
        Look();
      
    }

    new void Look()
    {
        #region PC
        Vector3 diff = point_gameObject.transform.position - transform.position;

        
        rot = Quaternion.LookRotation(-diff, Vector3.left);
        transform.rotation = rot;
        ls.transform.position = point_gameObject.transform.position+ Vector3.up* sprite_height;

        #endregion
    }

    new void Shoot()
    {
         base.Shoot();
    }

   
}