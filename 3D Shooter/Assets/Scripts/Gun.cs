using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected RaycastHit hit;
    protected Ray ray;

    protected Quaternion rot;



    public float rateOfFire1;

    public float shootForce1;

    public float sprite_height1;

    public float lookSpeed1;

    public float lerpSpeed1;

    [HideInInspector]
    public Vector3 point;
    [HideInInspector]
    public Vector3 originalPos;
    private float timer = 0;

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

    }
    public void Update()
    {
        
    }

    protected virtual void Look() { }

    public void Shoot()
    {

       
    }


}
