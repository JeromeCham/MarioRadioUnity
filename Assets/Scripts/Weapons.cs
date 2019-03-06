using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Inventory
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public float bulletLife = 1;
    public int ammo = 10;

    void Update()
    {
        if(gun == true)
        {
            Fire();
        }
        if (drop == true && count <= 1)
        {
            Create();
            count += 1;
        }
    }
    void Fire()
    {
        switch (selectobject)
        {
            case "Gun":
                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    Shoot();
                }
                break;
            case "Machine gun":
                if (Input.GetButton("Fire1") && ammo > 0)
                {
                    Shoot();
                }
                break;
        }
    }
    void Shoot()
    {
        bullet = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Destroy(bullet, bulletLife);
        ammo -= 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Magazine")
        {
            ammo += 30;
            Destroy(other.gameObject);
        }
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

    public GameObject MachinegunPrefab;
    public GameObject Machinegun2;

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
            case "Machine gun":
                Machinegun2 = (GameObject)Instantiate(MachinegunPrefab, DropPoint.position, DropPoint.rotation);
                break;

        }
        count = 0;
        drop = false;
    }
}
