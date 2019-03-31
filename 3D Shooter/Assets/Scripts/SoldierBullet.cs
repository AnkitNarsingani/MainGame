using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour {


    PoolManager pm;
    public GameObject soldier;
    public Transform t;
  
    private void OnEnable()
    {

        SoldierShoot();
        Invoke("Deactivate", 2);
        
    }

    void SoldierShoot()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*Time.deltaTime*1000,ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {

        transform.position = t.transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<TrailRenderer>().Clear();
      


    }
   void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
