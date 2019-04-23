﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventaire : MonoBehaviour
{
    //UI
    #region Singleton
    [SerializeField]
    private TextMeshProUGUI moneyText = null;

    [SerializeField]
    private TextMeshProUGUI ammoText = null;

    [SerializeField]
    private GameObject ammoTextUI = null;

    [SerializeField]
    private int money = 50;

    [SerializeField]
    private GameObject imageArmeUI = null;

    private string tempMoney;
    private string tempAmmo;
    #endregion

    //Arme
    #region Singleton
    [SerializeField]
    private GameObject gunImage = null;

    [SerializeField]
    private GameObject machinegunImage = null;

    [SerializeField]
    private GameObject RocketImage = null;


    [SerializeField]
    private Transform firePoint = null;

    [SerializeField]
    private Transform dropPoint = null;

    [SerializeField]
    private Arme pistolet = null;

    [SerializeField]
    private Arme mitraillette = null;

    [SerializeField]
    private Arme bazouka = null;

    private bool shoot = false;

    private int ammo = 0;
    #endregion

    //Potion
    #region Singleton
    [SerializeField]
    private Potion potionverte = null;

    [SerializeField]
    private Potion potionrouge = null;

    [SerializeField]
    private Potion potionbleue = null;
    #endregion

    //Inventaire
    #region Singleton
    public static Inventaire instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private bool drop = false;

    private int count = 0;

    [SerializeField]
    private string selectobject = "";

    [SerializeField]
    private string objectname = "";

    public List<Item> items = new List<Item>();
    public int space = 6;
    #endregion
    public Animator animator;


    private void Awake()
    {
        tempMoney = moneyText.text;
        tempAmmo = ammoText.text;

        if (instance != null)
        {
            Debug.LogWarning("Plus qu'un inventaire");
            return;
        }
        instance = this;
    }

    void Update()
    {
        switch (selectobject)
        {
            case "Machine gun":
                ammo = mitraillette.Ammo;
                break;
            case "Gun":
                ammo = pistolet.Ammo;
                break;
            case "RocketLauncher":
                ammo = bazouka.Ammo;
                break;
            default:
                ammo = -1;
                break;
        }
        moneyText.text = money + tempMoney;
        if (ammo == -1)
        {
            ammoTextUI.SetActive(false);
        }
        else
        {
            ammoTextUI.SetActive(true);
        }
        ammoText.text = ammo + tempAmmo;


        if (shoot == true)
        {
            Fire();
        }

        if (drop == true && count <= 1)
        {
            Create();
            count += 1;
        }
    }
    public bool Add(Item item)
    {
        animator.SetBool("Start", true);
        if (items.Count >= space)
        {
            //Debug.Log("Not enough room");
            return false;
        }
        //Debug.Log("Adding " + item.name + " to inventory");
        items.Add(item);
        //selectobject = item.name;
       // Debug.Log(item.name);
        if (item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
            selectobject = item.name;
            shoot = true;
            imageArmeUI.GetComponent<Image>().sprite = item.icon;
            var tempcolor = imageArmeUI.GetComponent<Image>().color;
            tempcolor.a = 255f;
            imageArmeUI.GetComponent<Image>().color = tempcolor;
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }
    public void Remove(Item item)
    {
        //Debug.Log("Removing " + item.name + " from inventory");
        items.Remove(item);
        objectname = item.name;
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        if (item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
            if (item.name == "Gun")
            {
                gunImage.SetActive(false);
                animator.SetBool("IsShooting", false);
            }
            if (item.name == "Machine gun")
            {
                machinegunImage.SetActive(false);
                animator.SetBool("IsShootingMg", false);
            }
            if (item.name == "RocketLauncher")
            {
                RocketImage.SetActive(false);
                animator.SetBool("IsShootingRl", false);
            }
            shoot = false;
            selectobject = null;
            imageArmeUI.GetComponent<Image>().sprite = null;
            var tempcolor = imageArmeUI.GetComponent<Image>().color;
            tempcolor.a = 0f;
            imageArmeUI.GetComponent<Image>().color = tempcolor;
        }
    }
    public void Drop(Item item)
    {
        drop = true;
    }
    public void SelectWeapon(Item item)
    {
        selectobject = item.name;
        shoot = true;
        imageArmeUI.GetComponent<Image>().sprite = item.icon;
        var tempcolor = imageArmeUI.GetComponent<Image>().color;
        tempcolor.a = 255f;
        imageArmeUI.GetComponent<Image>().color = tempcolor;
    }
    public void AddMagazinePistolet()
    {
        pistolet.Ammo += 60;
    }

    public void AddMagazineMitraillette()
    {
        mitraillette.Ammo += 150;
    }

    public void AddMagazineBazooka()
    {
        bazouka.Ammo += 5;
    }

    public int NbMoney()
    {
        return money;
    }
    public void MoinsShop()
    {
        money -= 10;
    }

    private void Fire()
    {
        switch (selectobject)
        {
            case "Machine gun":
                animator.SetBool("IsShooting", false);
                gunImage.SetActive(false);
                animator.SetBool("IsShootingMg", true);
                machinegunImage.SetActive(true);
                animator.SetBool("IsShootingRl", false);
                RocketImage.SetActive(false);
                if (Input.GetButton("Fire1") && mitraillette.Ammo > 0)
                {
                    mitraillette.Bullet = (GameObject)Instantiate(mitraillette.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(mitraillette.Bullet, mitraillette.BulletLife);
                    mitraillette.Ammo -= 1;
                }
                break;
            case "Gun":
                animator.SetBool("IsShooting", true);
                gunImage.SetActive(true);
                animator.SetBool("IsShootingMg", false);
                machinegunImage.SetActive(false);
                animator.SetBool("IsShootingRl", false);
                RocketImage.SetActive(false);
                if (Input.GetButtonDown("Fire1") && pistolet.Ammo > 0)
                {
                    pistolet.Bullet = (GameObject)Instantiate(pistolet.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(pistolet.Bullet, pistolet.BulletLife);
                    pistolet.Ammo -= 1;
                }
                break;
            case "RocketLauncher":
                animator.SetBool("IsShooting", false);
                gunImage.SetActive(false);
                animator.SetBool("IsShootingMg", false);
                machinegunImage.SetActive(false);
                animator.SetBool("IsShootingRl", true);
                RocketImage.SetActive(true);
                if (Input.GetButtonDown("Fire1") && bazouka.Ammo > 0)
                {
                    bazouka.Bullet = (GameObject)Instantiate(bazouka.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(bazouka.Bullet, bazouka.BulletLife);
                    bazouka.Ammo -= 1;
                }
                break;
        }
    }

    void Create()
    {
        switch (objectname)
        {
            case "Gun":
                pistolet.Gun = (GameObject)Instantiate(pistolet.GunPrefab, dropPoint.position, dropPoint.rotation);
                break;
            case "Machine gun":
                mitraillette.Gun = (GameObject)Instantiate(mitraillette.GunPrefab, dropPoint.position, dropPoint.rotation);
                break;
            case "RocketLauncher":
                bazouka.Gun = (GameObject)Instantiate(bazouka.GunPrefab, dropPoint.position, dropPoint.rotation);
                break;
            case "Green potion":
                potionverte.Potion2 = (GameObject)Instantiate(potionverte.PotionPrefab, dropPoint.position, dropPoint.rotation);
                break;
            case "Blue potion":
                potionbleue.Potion2 = (GameObject)Instantiate(potionbleue.PotionPrefab, dropPoint.position, dropPoint.rotation);
                break;
            case "Red potion":
                potionrouge.Potion2 = (GameObject)Instantiate(potionrouge.PotionPrefab, dropPoint.position, dropPoint.rotation);
                break;
        }
        count = 0;
        drop = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Magazine")
        {
            Inventaire.instance.AddMagazinePistolet();
            Destroy(other.gameObject);
        }
        if (other.tag == "MagazineMitraillette")
        {
            Inventaire.instance.AddMagazineMitraillette();
            Destroy(other.gameObject);
        }
        if (other.tag == "MagazineBazouka")
        {
            Inventaire.instance.AddMagazineBazooka();
            Destroy(other.gameObject);
        }
    }
}
