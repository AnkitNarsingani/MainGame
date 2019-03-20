using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotate UI to Move

public class GunRotation : Gun
{



    public GameObject point_gameObject;
    private float h, v;
    private GunJoyStick gun_joyStick;
   
    new void Start()
    {
        gun_joyStick = FindObjectOfType<GunJoyStick>();
       
    }


    new void Update()
    {
        h = gun_joyStick.Horizontal();
        v = gun_joyStick.Vertical();

        if (v <= 0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, 0, -2 * v) * lookSpeed * Time.deltaTime);
        }
        else if (v >= 0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed * Time.deltaTime);
        }
        Look();

    }

    new void Look()
    {

        Vector3 diff = point_gameObject.transform.position - transform.position;


        rot = Quaternion.LookRotation(-diff, Vector3.left);
       
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime / lerpSpeed);

             ls.transform.position = point_gameObject.transform.position + Vector3.up * sprite_height;

    }

    new void Shoot()
    {
        base.Shoot();
    }


}