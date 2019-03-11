using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public int health;
    public delegate void Message();
    public event Message Death;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        Death();
    }

   
}
