using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Inventory
{
    [SerializeField]
    private GameObject pistol;

    [SerializeField]
    private GameObject machineGun;

    [SerializeField]
    private GameObject rocketLauncher;

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public GameObject RocketPrefab;
    public GameObject Rocket;
    public float bulletLife = 1;
    public float RocketLife = 1;

    void Update()
    {
        if (gun == true)
        {
            Fire();
        }

        if (drop == true && count <= 1)
        {
            Create();
            count += 1;
        }
        
        switch (selectobject)
        {
            case "Gun":
                machineGun.SetActive(false);
                rocketLauncher.SetActive(false);
                pistol.SetActive(true);
                break;

            case "Machine gun":
                pistol.SetActive(false);
                rocketLauncher.SetActive(false);
                machineGun.SetActive(true);
                break;

            case "RocketLauncher":
                pistol.SetActive(false);
                machineGun.SetActive(false);
                rocketLauncher.SetActive(true);
                break;
            default:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                rocketLauncher.SetActive(false);
                break;
        }
    }

    void Fire()
    {
        switch (selectobject)
        {
            case "Gun":
                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    bullet = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
                    Destroy(bullet, bulletLife);
                    ammo -= 1;
                }
                break;
            case "Machine gun":
                if (Input.GetButton("Fire1") && ammo > 0)
                {
                    bullet = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
                    Destroy(bullet, bulletLife);
                    ammo -= 1;
                }
                break;
            case "RocketLauncher":
                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    Rocket = (GameObject)Instantiate(RocketPrefab, FirePoint.position, FirePoint.rotation);
                    Destroy(Rocket, RocketLife);
                    ammo -= 1;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Magazine")
        {
            Weapons.instance.AddMagazine();
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

    public GameObject RocketLauncherPrefab;
    public GameObject RocketLauncher;

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
            case "RocketLauncher":
                RocketLauncher = (GameObject)Instantiate(RocketLauncherPrefab, DropPoint.position, DropPoint.rotation);
                break;

        }
        count = 0;
        drop = false;
    }
}
