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
    private VirtualJoystick vj;

    void Start()
    {
        gun_joyStick = FindObjectOfType<GunJoyStick>();
        vj = FindObjectOfType<VirtualJoystick>();
    }


    new void Update()
    {

        base.Update();
        h = vj.Horizontal();
        v = vj.Vertical();

        if (v <= 0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, 0, -2 * v) * lookSpeed1 * Time.deltaTime);
        }
        else if (v >= 0)
        {
            point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed1 * Time.deltaTime);
        }



        Look();

    }

    new void Look()
    {

        Vector3 diff = point_gameObject.transform.position - transform.position;
        rot = Quaternion.LookRotation(-diff, Vector3.left);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime / lerpSpeed1);
        ls.transform.position = point_gameObject.transform.position + Vector3.up * sprite_height1;

    }

    new void Shoot()
    {
     base.Shoot();
    }


}