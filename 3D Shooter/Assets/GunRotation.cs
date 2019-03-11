using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunRotation : MonoBehaviour {

    int layerMask;
    Quaternion startRot;

    void Start ()
    {
        layerMask = 1 << 5;

    }
	
	// Update is called once per frame
	void Update ()
    {
       
       
	}
    public void MouseDown()
    {
         startRot = transform.rotation;

    }
    public void OnMouseDrag()
    {

      
    }

    public void MouseUp()
    {
        
    }
}

