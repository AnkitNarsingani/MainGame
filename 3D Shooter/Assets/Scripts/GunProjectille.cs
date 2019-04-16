using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GunProjectille : Gun
{

    //Direct Touch to Move

    public GameObject point_gameObject;
    public GameObject tobj;

    private float h, v;
    Touch touch;
    private Vector3 delta = Vector3.zero;
    Vector3 gettouch;
    Vector3 offset;
    Vector3 loc;
    bool stayed;
    void Start()
    {
        Ground = 1 << 8;
        ray = new Ray(point_gameObject.transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
        {
            {
                point = hit.point;
                point_gameObject.transform.position = point;

            }

        }
    }






    new void Update()
    {
        base.Update();
        Look();
        ls.transform.position = point_gameObject.transform.position + new Vector3(0, sprite_height1, 0);

      //  Clamp();
    }

    new void Look()
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Input.touchCount == 0) return;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                tobj.transform.position = hit.point;
                offset = tobj.transform.position - point_gameObject.transform.position;


            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                //tobj.transform.position = hit.point;

                print(offset);
                point_gameObject.transform.position = hit.point + offset;


            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                Debug.Log("Ended Touch");
                offset = Vector3.zero;

            }

            Vector3 diff = point_gameObject.transform.position - transform.position;
            rot = Quaternion.LookRotation(-diff, Vector3.left);
            transform.rotation = rot;
        }







    }



    void Clamp()
    {
        point_gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.z, -47f, 17f), 0, 0);
        point_gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -33f, 33f), 0, 0);
    }



    new void Shoot()
    {
        base.Shoot();
    }


    //new void Look()
    //{


    //    for (var i = 0; i < Input.touchCount; ++i)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
    //        gettouch = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
    //        switch (Input.GetTouch(i).phase)
    //        {
    //            case TouchPhase.Began:
    //                if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
    //                {

    //                    point = hit.point;
    //                    point.y = 0;
    //                }

    //                break;
    //            case TouchPhase.Moved:

    //                if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
    //                {

    //                    point = hit.point;
    //                    point.y = 0;
    //                    // originalPos = transform.position - hit.point;

    //                    point_gameObject.transform.position += delta * 1 * Time.deltaTime;

    //                    // point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed1 * Time.deltaTime);
    //                    Vector3 diff = point_gameObject.transform.position - transform.position + delta;
    //                    rot = Quaternion.LookRotation(-diff, Vector3.left);

    //                    ls.transform.position = point + new Vector3(0, sprite_height1, 0);
    //                }
    //                transform.rotation = rot;
    //                break;
    //            case TouchPhase.Ended:
    //                delta = Vector3.zero;
    //                point_gameObject.transform.position = Vector3.zero;
    //                break;

    //        }






    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(tobj.transform.position, point_gameObject.transform.position);

    }

}
