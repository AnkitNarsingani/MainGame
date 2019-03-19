using System.Collections;
using UnityEngine;

public class EnemySniper : Enemy
{
    public float shootTime = 1;

    private float alpha = 1.0f;
    private float Timer = 0;

    LineRenderer laser;
    Light pointLight;
    Color c;
    Vector3 diff;
    Vector3 playerPos;


    protected override void Start()
    {
        base.Start();
        laser = GetComponentInChildren<LineRenderer>();
        pointLight = GetComponentInChildren<Light>();
        alpha = 1;
        c = new Color(100, 86, 35);
        SetLaserColor(Color.red);
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
                if (damageableObject != null)
                {
                    StartCoroutine("Shoot");
                    damageableObject.TakeDamage(damageAmount);
                }
            }
            
            Timer = 0;
        }
        else
        {
            Aim();
        }
    }

    void Aim()
    {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, friendlyAI.transform.position);
        transform.LookAt(friendlyAI.transform.position);
    }

    IEnumerator Shoot()
    {
        pointLight.enabled = true;
        SetLaserColor(c);
        laser.startWidth = 0.05f;
        laser.endWidth = 0.05f;

        yield return new WaitForSeconds(shootTime);
        laser.startWidth = 0.01f;
        laser.endWidth = 0.01f;
        pointLight.enabled = false;
        SetLaserColor(Color.red);
    }

    void SetLaserColor(Color color)
    {

        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0), new GradientAlphaKey(alpha, 1) });

        laser.colorGradient = gradient;
    }

    public override void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Die();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

}
