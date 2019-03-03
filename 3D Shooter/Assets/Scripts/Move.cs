using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    void Update ()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"),0, -Input.GetAxis("Vertical"));
        transform.Translate(move * 3*Time.deltaTime) ;
	}

    public void Die(float leastHealth)
    {

    }
}
