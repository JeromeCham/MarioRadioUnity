using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Inventory
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public float bulletLife = 1;

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

    public GameObject GreenPotionPrefab;
    public GameObject GreenPotion;

    public GameObject RedPotionPrefab;
    public GameObject RedPotion;

    public GameObject BluePotionPrefab;
    public GameObject BluePotion;

    public int count = 0;


    void Create()
    {
        switch (objectname)
        {
            case "Gun":
                gun2 = (GameObject)Instantiate(GunPrefab, DropPoint.position, DropPoint.rotation);
                break;
            case "Green potion":
                GreenPotion = (GameObject)Instantiate(GreenPotionPrefab, DropPoint.position, DropPoint.rotation);
                break;
            case "Red potion":
                RedPotion = (GameObject)Instantiate(RedPotionPrefab, DropPoint.position, DropPoint.rotation);
                break;
            case "Blue potion":
                BluePotion = (GameObject)Instantiate(BluePotionPrefab, DropPoint.position, DropPoint.rotation);
                break;

        }
        count = 0;
        drop = false;
    }
}
