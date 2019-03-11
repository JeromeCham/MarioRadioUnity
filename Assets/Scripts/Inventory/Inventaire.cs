using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private Transform dropPoint;

    [SerializeField]
    private Arme pistolet;

    [SerializeField]
    private Arme mitraillette;

    [SerializeField]
    private Arme bazouka;

    [SerializeField]
    private Potion potionverte;

    [SerializeField]
    private Potion potionrouge;

    [SerializeField]
    private Potion potionbleue;

    [SerializeField]
    private GameObject imageArmeUI;

    #region Singleton
    public static Inventaire instance;
    private bool shoot = false;
    private bool drop = false;

    [SerializeField]
    private string selectobject = "";

    [SerializeField]
    private string objectname = "";

    private int ammo = 0;
    private int count = 0;

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 6;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus qu'un inventaire");
            return;
        }
        instance = this;
    }


    void Update()
    {
        
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
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        Debug.Log("Adding " + item.name + " to inventory");
        items.Add(item);
        selectobject = item.name;
        Debug.Log(item.name);
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
        Debug.Log("Removing " + item.name + " from inventory");
        items.Remove(item);
        objectname = item.name;
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        if (item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
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
    public void AddMagazine()
    {
        ammo += 30;
    }
    public int NbAmmo()
    {
        return ammo;
    }

    private void Fire()
    {
        switch (selectobject)
        {
            case "Machine gun":
                if (Input.GetButton("Fire1") && ammo > 0)
                {
                    mitraillette.Bullet = (GameObject)Instantiate(mitraillette.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(mitraillette.Bullet, mitraillette.BulletLife);
                    ammo -= 1;
                }
                break;
            case "Gun":
                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    pistolet.Bullet = (GameObject)Instantiate(pistolet.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(pistolet.Bullet, pistolet.BulletLife);
                    ammo -= 1;
                }
                break;
            case "RocketLauncher":
                if (Input.GetButtonDown("Fire1") && ammo > 0)
                {
                    bazouka.Bullet = (GameObject)Instantiate(bazouka.BulletPrefab, firePoint.position, firePoint.rotation);
                    Destroy(bazouka.Bullet, bazouka.BulletLife);
                    ammo -= 1;
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
            Inventaire.instance.AddMagazine();
            Destroy(other.gameObject);
        }
    }
}
