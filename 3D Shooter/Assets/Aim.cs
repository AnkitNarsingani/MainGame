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
        chest = anim.GetBoneTransform(HumanBodyBones.Chest);

    }
    void LateUpdate()
    {
        if (!see) return;
        else
        {

            chest.LookAt(target);
            chest.rotation = chest.rotation * Quaternion.Euler(offset);
        }


    }
}
