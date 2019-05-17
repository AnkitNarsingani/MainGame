using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    Vector3 startPos;
    public float shakeTime = 0.5f;
    public float shakeMagnitude = 1f;

    void Start()
    {

        InvokeRepeating("CamShake", 0, 0.005f);
        Invoke("Stop", shakeTime);
    }

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("CamShake", 0, 0.005f);
            Invoke("Stop", shakeTime);
        }

    }

    void CamShake()
    {
        float deltaX = Random.value * shakeMagnitude;
        float deltaY = Random.value * shakeMagnitude;
        Vector3 tempPos = startPos;
        tempPos.x += deltaX;
        tempPos.y += deltaY;
        Camera.main.transform.position = tempPos;
    }

    void Stop()
    {
        CancelInvoke("CamShake");
        Camera.main.transform.position = startPos;

    }
}
