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
    public bool see = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        startAngle = chest.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!see) return;
        else
        {
            Vector3 direction = (transform.position - target.position).normalized;
            float angle = Vector3.Angle(transform.forward, direction);


            chest.LookAt(target.position);
            chest.rotation = chest.rotation * Quaternion.Euler(offset);
        }
        

    }
}
