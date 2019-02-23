using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	void Start ()
    {
        FindObjectOfType<FriendlyAI>().RegisterEmemy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
