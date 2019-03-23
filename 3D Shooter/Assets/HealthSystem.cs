using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    Vector3 diff;
    RectTransform rt;

    void Start () {
        rt = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
      ;
        rt.transform.position = transform.position;
	}
}
