using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectille : Gun {

//Direct Touch to Move
    Vector3 point;
    Vector3 originalPos;

    void Start ()
    {
        Ground = LayerMask.GetMask("Ground");
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls = Instantiate(lockSprite, point, sprite_opp);
    }
	

	new void  Update ()
    {
        Look();
        base.Update();
	}

    new void Look()
    {
        #region PC
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Ground))
        {
            {
                point = hit.point;
                point.y = 0;
                originalPos = transform.position - hit.point;

                rot = Quaternion.LookRotation(originalPos, Vector3.left);
                if (originalPos.magnitude > 1)
                    transform.rotation = rot;

                ls.transform.position = point + new Vector3(0, sprite_height, 0);
            }
            #endregion
        }
    }

    new void Shoot()
    {
        base.Shoot();
    }
}
