using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Inventory
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public float bulletLife = 1;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && gun == true)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        bullet = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(bullet, bulletLife);
    }

}
