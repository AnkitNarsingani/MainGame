using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    void Update ()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Vertical"),0, 0);
        transform.Translate(move * 3*Time.deltaTime) ;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*50, 0) * Time.deltaTime);
	}

    public void Die(float leastHealth)
    {

    }
}
