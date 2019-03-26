using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explision;
    [HideInInspector] public float bulletDamage;

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        FriendlyAI friendlyAI = collision.gameObject.GetComponent<FriendlyAI>();
        if (damageable != null && friendlyAI == null)
        {
            damageable.TakeDamage(bulletDamage);
        }
        Instantiate(explision, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}
