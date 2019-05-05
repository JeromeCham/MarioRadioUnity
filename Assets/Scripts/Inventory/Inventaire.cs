using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Inventaire : MonoBehaviour
{   
    public static Inventaire instance;
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

    public Arme Pistolet
    {
        get
        {
            return pistolet;
        }

        set
        {
            pistolet = value;
        }
    }
    public Arme Mitraillette
    {
        get
        {
            return mitraillette;
        }

        set
        {
            mitraillette = value;
        }
    }
    public Arme Bazouka
    {
        get
        {
            return bazouka;
        }

        set
        {
            bazouka = value;
        }
    }
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

    //SaveInventaire
    #region Singleton
    [SerializeField]
    private ScriptableObject item1 = null;

    [SerializeField]
    private ScriptableObject item2 = null;

    [SerializeField]
    private ScriptableObject item3 = null;

    [SerializeField]
    private ScriptableObject item4 = null;

    [SerializeField]
    private ScriptableObject item5 = null;

    [SerializeField]
    private ScriptableObject item6 = null;
    #endregion

    private void Awake()
    {
        Load();
        if (instance != null)
        {
            return;
        }
        instance = this;
        tempMoney = moneyText.text;
        tempAmmo = ammoText.text;
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            PLayerDataSave data = bf.Deserialize(file) as PLayerDataSave;
            file.Close();

            pistolet.Ammo = data.AmmoPistolet;
            mitraillette.Ammo = data.AmmoMitraillette;
            bazouka.Ammo = data.AmmoBazooka;
            money = data.Money;

            if(data.Items == null)
            {
                data.Items = new List<int>();
            }
            
            for (int i = 0; i < data.Items.Count; i++)
            {
                
                if (data.Items[i] == 1)
                {
                    items.Add((Item)item1);
                    //FindObjectOfType<InventoryUI>().slots[i].AddItem((Item)item1);
                }
                else if (data.Items[i] == 2)
                {
                    items.Add((Item)item2);
                }
                else if (data.Items[i] == 3)
                {
                    items.Add((Item)item3);
                }
                else if (data.Items[i] == 4)
                {
                    items.Add((Item)item4);
                }
                else if (data.Items[i] == 5)
                {
                    items.Add((Item)item5);
                }
                else if (data.Items[i] == 6)
                {
                    items.Add((Item)item6);
                }
            }
        }
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
            return false;
        }
        items.Add(item);
        if (item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
            if (item.name == "Gun" || item.name == "Machine gun")
            {
                Soundmanager.PlaySound("pickupgun");
            }
            selectobject = item.name;
            shoot = true;
            imageArmeUI.GetComponent<Image>().sprite = item.icon;
            var tempcolor = imageArmeUI.GetComponent<Image>().color;
            tempcolor.a = 255f;
            imageArmeUI.GetComponent<Image>().color = tempcolor;
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
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
        pistolet.Ammo += 15;
    }

    public void AddMagazineMitraillette()
    {
        mitraillette.Ammo += 50;
    }

    public void AddMagazineBazooka()
    {
        bazouka.Ammo += 2;
    }

    public int NbMoney()
    {
        return money;
    }
    public void AddMoney(int money2)
    {
        money += money2;
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
                    Soundmanager.PlaySound("gunshot");
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
                    Soundmanager.PlaySound("gunshot");
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

    