using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour {

 
   

    private void OnEnable()
    {
        SoldierShoot();
    }

    void SoldierShoot()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*Time.deltaTime*100,ForceMode.Impulse);
    }
}
