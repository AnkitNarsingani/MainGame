using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{

   
    public int currentGun = 0;
   
    public GameObject[] gunObject = new GameObject[1];
    public GameObject[] points = new GameObject[1];
    public GameObject[] GunUI = new GameObject[1];
    int i;
    private void Start()
    {
        
        check();
    }
    void Update()
    {
     

    }
    void check()
    {
       
        foreach (Transform t in transform)
        {
            if (i > t.childCount - 1)
                i = 0;
            else
                i++;
            if (i == currentGun)
                EnableGun(gunObject[currentGun], points[currentGun], GunUI[currentGun]);
            else
                DisableGun(gunObject[currentGun], points[currentGun], GunUI[currentGun]);

           
        }
       
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
            check();


        }
        if (GUI.Button(new Rect(60, 10, 50, 50), "GunTouch"))
        {
            currentGun = 0;
            check();
        }

    }
}
