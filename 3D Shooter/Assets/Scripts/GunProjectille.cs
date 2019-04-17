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
    Vector3 currentScreenPos, screenPos, currentPos;
    Vector3 offset;
    Vector3 loc;
    float deltaX, deltaY;
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
        Touch f0 = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Input.touchCount == 0) return;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100000,Ground))
        {
          
           
                if (f0.phase == TouchPhase.Began)
                {
                    screenPos = Camera.main.WorldToScreenPoint(point_gameObject.transform.position);
                    offset = point_gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(f0.position.x, f0.position.y, screenPos.z));
                }
                else if (f0.phase == TouchPhase.Moved)
                {
                    currentScreenPos = new Vector3(f0.position.x, f0.position.y, screenPos.z);
                    currentPos = Camera.main.ScreenToWorldPoint(currentScreenPos) + offset;
                    point_gameObject.transform.position = currentPos;
                }
            
        }
    

    Vector3 diff = point_gameObject.transform.position - transform.position;
         rot = Quaternion.LookRotation(-diff, Vector3.left);
          transform.rotation = rot;
        







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

    //        if (Input.GetTouch(0).phase == TouchPhase.Began)
    //            {

    //                tobj.transform.position = hit.point;
    //                offset = tobj.transform.position - point_gameObject.transform.position;


    //            }
    //            if (Input.GetTouch(0).phase == TouchPhase.Moved)
    //            {

    //                //tobj.transform.position = hit.point;

    //                print(offset);
    //point_gameObject.transform.Translate(tobj.transform.position.x - offset.x,  tobj.transform.position.z - offset.z,0);


    //            }
    //            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
    //            {
    //                Debug.Log("Ended Touch");
    //                offset = Vector3.zero;

    //            }

    //            Vector3 diff = point_gameObject.transform.position - transform.position;
    //rot = Quaternion.LookRotation(-diff, Vector3.left);
    //            transform.rotation = rot;
    //        }





    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(tobj.transform.position, point_gameObject.transform.position);

    }

}
