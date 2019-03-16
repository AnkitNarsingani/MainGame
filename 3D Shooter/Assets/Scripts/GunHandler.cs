using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GunHandler : MonoBehaviour {

    public bool GunJoyStick = false;
    public bool GunTouch = false;
    public GameObject[]gunObject =new GameObject[1];
    public GameObject[]points =new GameObject[1];
    public GameObject[]GunUI =new GameObject[1];

    void Update ()
    {
		if(GunJoyStick==true)
        {
            EnableGun(gunObject[1], points[1], GunUI[1]);
            
        }
        else
            DisableGun(gunObject[1], points[1], GunUI[1]);


        if (GunTouch == true)
        {
            EnableGun(gunObject[0], points[0], GunUI[0]);

        }
        else
            DisableGun(gunObject[0], points[0], GunUI[0]);

    }
    void EnableGun(GameObject gun, GameObject point,GameObject ui)
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
            GunJoyStick = true;
            GunTouch = false;
        }
        if (GUI.Button(new Rect(60, 10, 50, 50), "GunTouch"))
        {
            GunJoyStick = false;
            GunTouch = true;
        }

    }
}
