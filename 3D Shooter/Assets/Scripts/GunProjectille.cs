using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GunProjectille : Gun
{

    //Direct Touch to Move

    public GameObject point_gameObject;
    private float h, v;

    void Start()
    {
        Ground = 1 << 8;
    }



    new void Update()
    {
        base.Update();
        point_gameObject.transform.Translate(new Vector3(-h, v, 0) * lookSpeed1 * Time.deltaTime);
        Look();
    }

    new void Look()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
        {
            
                point = hit.point;
                point.y = 0;
                originalPos = transform.position - hit.point;

                rot = Quaternion.LookRotation(originalPos, Vector3.left);
                ls.transform.position = point + new Vector3(0, sprite_height1, 0);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * lookSpeed1);

    }

    new void Shoot()
    {
        base.Shoot();
    }


}
