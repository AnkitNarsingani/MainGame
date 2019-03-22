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
    protected GunHandler gh;

    [HideInInspector]
    public float shootForce1;
    [HideInInspector]
    public float sprite_height1;
    [HideInInspector]
    public float lookSpeed1;
    [HideInInspector]
    public float lerpSpeed1;

    [HideInInspector]
    public Vector3 point;
    [HideInInspector]
    public Vector3 originalPos;
    

    [HideInInspector]
    public GameObject bulletPrefab;
    [HideInInspector]
    public GameObject lockSprite;
    public Transform bulletSpawn;
    public GameObject ls;
    public float gunDamage = 10;


    public void Awake()
    {
        point = Vector3.zero;
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls.transform.rotation = sprite_opp;
        gh = FindObjectOfType<GunHandler>();
    }
    public void Update()
    {
        shootForce1 = gh.shootForce;
        lerpSpeed1 = gh.lerpSpeed;
        sprite_height1 = gh.sprite_height;
        lookSpeed1 = gh.lookSpeed;
    }

    protected virtual void Look() { }

    public void Shoot()
    {
        Rigidbody rb;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().bulletDamage = gunDamage; //Add after Object Pool
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * 1000 * shootForce1);
        rb.rotation = rot;
    }
}
