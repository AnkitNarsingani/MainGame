using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class GunProjectille : MonoBehaviour
{

    [HideInInspector]
    public Vector3 point;
    [HideInInspector]
    public Vector3 originalPos;
   
    public GameObject bulletPrefab;

    private float timer = 0;
    public float gunDamage = 10;
    public GameObject point_gameObject;
    public Transform bulletSpawn;
    public GameObject ls;
    Vector3 currentScreenPos, screenPos, currentPos;
    Vector3 offset;
    Vector3 diff;
    Touch f0;
    RaycastHit fHit, hit;
    Ray ray;
    Hold h;
    Quaternion rot;
    int Ground;
    float touchTimer = 0;
    public float shootForce1;
    public float rateOfFire1;
    public float sprite_height1;
    public bool singleRate = false;
    float cT = 1;
    bool shooting = false;
    bool touching = false;

    public void Awake()
    {
        point = Vector3.zero;
        Quaternion sprite_opp = Quaternion.LookRotation(Vector3.up);
        ls.transform.rotation = sprite_opp;

    }
    void Start()
    {
        Ground = 1 << 8;

        h = FindObjectOfType<Hold>();
        ray = new Ray(point_gameObject.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
        {
            point = hit.point;
            point_gameObject.transform.position = point;

        }

    }


    void Update()
    {
        timer += Time.deltaTime;

        Look();
        ShootType();


    }
    void ShootType()
    {
        if (h.shoot)
        {
            if (singleRate)//Single Fire
            {
                if (timer > rateOfFire1)
                {
                    timer = 0;
                    Shoot();
                    h.shoot = false;
                }
            }
            else//Hold and Tap
            {

                if (shooting == false)
                {
                    shooting = true;
                    cT = 1;
                    StartCoroutine("Shooting");

                }

            }
        }
        else
        {
            StopAllCoroutines();
            shooting = false;
        }
    }
    void Look()
    {


        if (Input.touchCount == 0) return;
        else
        {
            f0 = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(f0.position);
            if (Physics.Raycast(ray, out hit, 100000, Ground))
            {



                if (f0.phase == TouchPhase.Began)
                {
                    touchTimer = 0;
                    screenPos = Camera.main.WorldToScreenPoint(point_gameObject.transform.position);
                    offset = point_gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(f0.position.x, f0.position.y, screenPos.z));
                }
                else if (f0.phase == TouchPhase.Moved)
                {
                    touchTimer += Time.deltaTime;
                    if (touchTimer > 0.05f)
                    {

                        touchTimer = 0;
                        currentScreenPos = new Vector3(f0.position.x, f0.position.y, screenPos.z);
                        currentPos = Camera.main.ScreenToWorldPoint(currentScreenPos) + offset;
                        if (currentPos.y <= 0)
                            currentPos.y = 0;
                        point_gameObject.transform.position = currentPos;
                        point_gameObject.transform.position = new Vector3(Mathf.Clamp(point_gameObject.transform.position.x, -12.5f, 12.5f), 0, Mathf.Clamp(point_gameObject.transform.position.z, -25, 19));

                    }

                }
            }



            LookAt();
        }


    }
    bool IsPointerOverUI()
    {
        foreach (Touch t in Input.touches)
        {
            if (EventSystem.current.IsPointerOverGameObject(t.fingerId))
            {
                return true;
            }

        }
        return false;
    }


    void Shoot()
    {
        Rigidbody rb;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().bulletDamage = gunDamage; //Add after Object Pool
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * 1000 * shootForce1);
        rb.rotation = rot;

    }

    void LookAt()
    {
        diff = point_gameObject.transform.position - transform.position;
        rot = Quaternion.LookRotation(-diff, Vector3.left);

        transform.rotation = rot;
        if (Physics.Raycast(transform.position, diff, out fHit, 100000, Ground))
        {
            ls.transform.position = fHit.point;
        }
    }
    IEnumerator Shooting()
    {

        while (shooting)
        {
            Shoot();
            yield return new WaitForSeconds(cT);
            cT = cT - (Time.deltaTime * 25);
            cT = Mathf.Clamp(cT, 0.25f, 1);
        }


    }

    public void SelectFire()
    {
        singleRate = !singleRate;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, diff);
    }

}
