using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointToCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(mainCamera.transform);
    }
}
