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
    public float shootForce = 1;
    public float gunDamage = 10;

    public float spriteHeight;
    [HideInInspector] public GameObject ls;
    [HideInInspector] public GameObject bullet;


    void Start()
    {

    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    protected virtual void Look()
    {

    }

    protected virtual void Shoot()
    {
        bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody>();
        bullet.GetComponent<Bullet>().damageAmount = gunDamage;
        rb.AddForce(-transform.forward * 1000 * shootForce);
        rb.rotation = rot;
    }

}
