using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public FriendlyAI aiScript;
	void Start ()
    {
        aiScript.RegisterEmemy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
