using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float health;
    protected static GameObject friendlyAI;
    [SerializeField] protected float damageAmount = 10;

    void Start()
    {

    }

    void Update()
    {

    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }
}
