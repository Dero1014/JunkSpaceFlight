using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Muzzle : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullet;

    public float fireRate;

    private float timeToFire = 0;

    private void Start()
    {
        muzzle = gameObject.GetComponentInChildren<MuzzleFind_Script>().transform; //the script is used to find the component that we are looking for

        timeToFire = fireRate;
    }

    GameObject clone;
    public void Shoot(bool shoot)
    {
        //fire bullets 
        if (shoot)
        {
            timeToFire += Time.deltaTime;
            if (timeToFire > fireRate)
            {
                //fire bullet
                clone = Instantiate(bullet, muzzle.position, Quaternion.identity);
                clone.transform.up = muzzle.up;
                clone.GetComponent<Bullet_Script>().GetDirection(muzzle);
                clone = null;

                timeToFire = 0;
            }
        }
        else
        {
            timeToFire = 0;
        }
    }

    public void JustShootOnce()
    {
        clone = Instantiate(bullet, muzzle.position, Quaternion.identity);

        clone.GetComponent<Bullet_Script>().GetDirection(muzzle);   
    }
}
