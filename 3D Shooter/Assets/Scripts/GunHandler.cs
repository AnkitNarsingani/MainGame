using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{

    [SerializeField]
    [Range(1,0.1f)]
    public float rateOfFire = 1;
    [SerializeField]
    public float shootForce;
    [SerializeField]
    public float sprite_height;
    [SerializeField]
    public float lookSpeed;
    [Range(0.1f, 1)]
    public float lerpSpeed;
    [SerializeField]
    protected GameObject[] gunObject = new GameObject[1];
    [SerializeField]
    protected GameObject[] points = new GameObject[1];
    [SerializeField]
    protected GameObject[] GunUI = new GameObject[1];

    public int currentGun = 0;
    int i;
    GunProjectille gp;
    GunRotation gr;

    void Awake()
    {
        check(currentGun);
    }


    void Update() { }
   

    void check(int currentGUN)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DisableGun(gunObject[i], points[i], GunUI[i]);
        }
        EnableGun(gunObject[currentGun], points[currentGun], GunUI[currentGun]);
    }


    void EnableGun(GameObject gun, GameObject point, GameObject ui)
    {
        gun.SetActive(true);
        point.SetActive(true);
        ui.SetActive(true);
    }
    void DisableGun(GameObject gun, GameObject point, GameObject ui)
    {
        if (gun != null && point != null && ui != null)
        {
            gun.SetActive(false);
            point.SetActive(false);
            ui.SetActive(false);
        }
    }
    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 50, 50), "GunJoyStick"))
        {
            currentGun = 1;
            check(currentGun);

        }
        if (GUI.Button(new Rect(60, 10, 50, 50), "GunTouch"))
        {
            currentGun = 0;
            check(currentGun);
        }

    }
}
