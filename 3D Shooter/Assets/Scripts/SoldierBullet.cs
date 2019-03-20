using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour {


    PoolManager pm;
    public GameObject soldier;
    private void OnEnable()
    {
      
       
    }

    void SoldierShoot()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*Time.deltaTime*1000,ForceMode.Impulse);
    }
}
