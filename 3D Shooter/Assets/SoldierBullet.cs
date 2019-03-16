using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour {

    public GameObject target;

    private void OnEnable()
    {
        SoldierShoot(transform.position, target.transform.position);
    }

    void SoldierShoot(Vector3 start,Vector3 target)
    {
        GetComponent<Rigidbody>().AddForce(target*Time.deltaTime*25);
    }
}
