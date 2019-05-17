using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    Animator anim;
    public Transform chest;
    public Transform target;
    public Vector3 offset;
    public float maxAngle = 60;
    Vector3 startAngle;
    void Start()
    {
        anim = GetComponent<Animator>();
         startAngle = chest.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = (transform.position - target.position).normalized;
        float angle = Vector3.Angle(transform.forward, direction);
        if (angle < maxAngle)
        {
            chest.LookAt(target.position);
            chest.rotation = chest.rotation * Quaternion.Euler(offset);
        }
        else
        {
            chest.LookAt(startAngle);
        }
    }
}
