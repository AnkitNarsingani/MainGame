using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    LayerMask Ground;
    Quaternion rot;
    Rigidbody rb;
  
    public GameObject bulletPrefab;
    public GameObject lockSprite;
    public Transform bulletSpawn;

    GameObject ls;
    GameObject bullet;

    Vector3 point;
    Vector3 originalPos;
   
    public float sprite_height;
    void Start()
    {
        Ground = LayerMask.GetMask("Ground");
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls = Instantiate(lockSprite, point , sprite_opp);
    }

    void Update()
    {
        Look();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        Shoot();
    }
 

    void Look()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Ground))
        {
            point = hit.point;
            point.y = 0;
            originalPos = transform.position - hit.point;

            rot = Quaternion.LookRotation(originalPos, Vector3.left);
            if (originalPos.magnitude > 1)
                transform.rotation = rot;

            ls.transform.position = point + new Vector3(0, sprite_height, 0);

        }

    }
    void Shoot()
    { 
        bullet = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        rb= bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward*1000);
        rb.rotation = rot;
     
    }

   
}
