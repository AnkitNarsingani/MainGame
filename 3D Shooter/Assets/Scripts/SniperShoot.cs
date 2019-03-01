using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShoot : MonoBehaviour
{
    public float shootTime = 1;
    public float alpha = 1.0f;
    public GameObject player;
    LineRenderer laser;
    Light pointLight;


    Vector3 diff;
    float Timer = 0;
    Vector3 playerPos;


    void Start()
    {
        laser = GetComponentInChildren<LineRenderer>();
        pointLight = GetComponentInChildren<Light>();
        alpha = 1;
        setLaserColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3)
        {
                      StartCoroutine("Shoot");
           
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
        laser.SetPosition(1, player.transform.position);
        transform.LookAt(player.transform.position);
    }
    IEnumerator Shoot()
    {
        pointLight.enabled = true;
        setLaserColor(Color.yellow);
        laser.startWidth = 1;
        laser.endWidth = 1;

        yield return new WaitForSeconds(shootTime);
        laser.startWidth = 0.5f;
        laser.endWidth = 0.5f;
        pointLight.enabled = false;
        setLaserColor(Color.red);
    }
    void setLaserColor(Color color)
    {

        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0), new GradientAlphaKey(alpha, 1) });

        laser.colorGradient = gradient;
    }
}
