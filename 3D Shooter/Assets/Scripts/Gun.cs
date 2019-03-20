using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : GunHandler
{
    protected RaycastHit hit;
    protected Ray ray;
    protected LayerMask Ground;
    protected Quaternion rot;
    protected Rigidbody rb;

   

    [HideInInspector]
    public Vector3 point;
    [HideInInspector]
    public Vector3 originalPos;
    

    [HideInInspector]
    public GameObject bulletPrefab;
    public GameObject lockSprite;
    public Transform bulletSpawn;

    
    public GameObject ls;
    [HideInInspector]
    public GameObject bullet;

    protected GunHandler gh;
    public void Awake()
    {
        point = Vector3.zero;
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls.transform.rotation = sprite_opp;
      
    }

   
    public void Update()
    {
       
    }
    protected virtual void Look() { }

    public void Shoot()
    {
        bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * 1000 * shootForce);
        rb.rotation = rot;
    }

}
