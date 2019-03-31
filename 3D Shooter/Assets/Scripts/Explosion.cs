using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField]
    private float radius = 1;


    void Start()
    {
        Collider[] objInRange = Physics.OverlapSphere(transform.position, radius);
        Destroy(gameObject, 1);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
