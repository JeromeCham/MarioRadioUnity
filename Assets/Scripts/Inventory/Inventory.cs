using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public bool gun = false;
    public bool drop = false;
    public string selectobject = " ";
    public string objectname = " ";
    public int ammo = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus qu'un inventaire");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 6;


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
        if (item.name == "Gun" || item.name == "Machine gun")
        {
            gun = true;
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
        if (item.name == "Gun" || item.name == "Machine gun")
        {
            gun = false;
        }
        //drop = true;
    }
    public void Drop(Item item)
    {
        drop = true;
    }
    public void SelectWeapon(Item item)
    {
        selectobject = item.name;
    }
    public void AddMagazine()
    {
        ammo += 30;
    }
}