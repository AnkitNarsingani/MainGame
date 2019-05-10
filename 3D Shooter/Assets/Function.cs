using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : MonoBehaviour
{

    public GameObject bullet;
    public float curve = 3;
    public float Maxcurve = 0.25f;
    float cT;
    float t;
    Rigidbody rb;

    void Start()
    {
        StartCoroutine("Shooting");
    }


    void Update()
    {

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    t += Time.deltaTime;
        //    cT = 1;
        //    //cT = getValue(t);
        //    cT = Mathf.Clamp(cT, 0.25f,1);
        //    cT -= Time.deltaTime;

        //    if (t >= cT)
        //    {
        //        cT = 0;
        //        Shoot();
        //    }

        //}
        //else if (Input.GetKeyUp(KeyCode.Mouse0))
        //{

        //    t = 0;
        //    cT = 1;
        //    print(cT);
        //    CancelInvoke("Shoot");
        //}


    }
    float getValue(float x)
    {
        if (x <= Maxcurve)
            return Maxcurve;
        else
            return 1 / (Mathf.Pow(x, 1.3f) + Mathf.Sin(x) + 1);
    }
    void Shoot()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(-transform.forward * 2500);
        Destroy(go, 2f);
    }
    IEnumerator Shooting()
    {

        cT = 1;
      
        while (true)
        {

            if (Input.GetButton("Fire1"))
            {

                Shoot();
                yield return new WaitForSeconds(cT);
                cT =cT- (Time.deltaTime *25);
                cT = Mathf.Clamp(cT, 0.1f, 1);
                print(cT);

            }
            yield return null;
        }
    }
}
