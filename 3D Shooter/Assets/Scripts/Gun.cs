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
    GameObject bullet;
    public GameObject bulletPrefab;
    public GameObject lockSprite;
    GameObject ls;
    public Transform bulletSpawn;
    Vector3 point;
    Vector3 originalPos;
    int layerMask;
    public float sprite_height;
    void Start()
    {
        int layerMask = 1 << 8;

       
        

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

            ls.transform.position = point+new Vector3(0, sprite_height, 0);

            // ls.transform.rotation = sprite_opp;
            float z_distance = transform.position.z - point.z;
            
        }

    }
    void Shoot()
    { 
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        rb= bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward*1000);
        rb.rotation = rot;
        Destroy(bullet, 1);
     
    }
    void Launch()
    {

    }
     Vector3 MoveVelocity()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = true;
        return Vector3.zero;
       
    }
   
}
