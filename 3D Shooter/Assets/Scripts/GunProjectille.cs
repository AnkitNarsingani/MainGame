using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GunProjectille : Gun
{

    //Direct Touch to Move

    public GameObject point_gameObject;
    private float h, v;

    new void Start()
    {
        Ground = 1 << 8;
    }



   new  void Update()
    {
        point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed * Time.deltaTime);
        Look();
    }

    new void Look()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Ground))
        {
            {
                point = hit.point;
                point.y = 0;
                originalPos = transform.position - hit.point;

                rot = Quaternion.LookRotation(originalPos, Vector3.left);

                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime / lookSpeed);

               ls.transform.position = point + new Vector3(0, sprite_height, 0);
            }

        }
    }

    new void Shoot()
    {
        base.Shoot();
    }


}
