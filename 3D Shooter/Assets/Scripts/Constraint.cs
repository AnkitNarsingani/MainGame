using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position= new Vector3(Mathf.Clamp(transform.position.x,-11.5f,11.5f), transform.position.y, Mathf.Clamp(transform.position.z, -5, 19));
		
	}
}
