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
        if (drop == true && count <= 1)
        {
            Create();
            count += 1;
        }
    }
    void Shoot()
    {
        bullet = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(bullet, bulletLife);
    }


    public Transform DropPoint;
    public GameObject GunPrefab;
    public GameObject gun2;
    public int count = 0;

    void Create()
    {
        gun2 = (GameObject)Instantiate(GunPrefab, DropPoint.position, DropPoint.rotation);
        count = 0;
        drop = false;
    }
}
