using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected RaycastHit hit;
    protected Ray ray;
    protected LayerMask Ground;
    protected Quaternion rot;
    protected Rigidbody rb;
  
    public GameObject bulletPrefab;
    public GameObject lockSprite;
    public Transform bulletSpawn;

    [HideInInspector]
    public float sprite_height;
    [HideInInspector]
    public GameObject ls;
    [HideInInspector]
    public GameObject bullet;

   
   void Start() { }
   protected virtual void Look() { }

    public void Update()
    {
        Look();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
 
   public void Shoot()
   { 
        bullet = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        rb= bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward*1000);
        rb.rotation = rot;
   }

   
}
