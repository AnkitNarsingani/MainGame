using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField]
    private float radius = 1;
    [SerializeField]
    private int dmgAmount = 1;


    void Start()
    {

        Collider[] objInRange = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in objInRange)
        {
         
            IDamageable damageable = c.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(dmgAmount);
            }
        }

        Destroy(gameObject, 1);

    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
