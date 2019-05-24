using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMove : MonoBehaviour
{


    Vector3 pos;
    Vector3 spos;
    public float magnitude = 1;
    public float amplitude = 1;
    void Start()
    {
        pos = transform.position;
        spos = transform.position;
    }

    void LateUpdate()
    {
        float height = 2 * Mathf.Sin(Time.time/amplitude)*magnitude;
        pos.y = height;
        transform.position = new Vector3(pos.x, pos.y + spos.y, pos.z);

    }
}
