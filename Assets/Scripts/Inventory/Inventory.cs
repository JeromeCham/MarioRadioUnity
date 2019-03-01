using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public bool gun = false;
    public bool drop = false;
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

        if (item.name == "Gun")
        {
            gun = true;
        }
        
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        if (item.name == "Gun")
        {
            gun = false;
        }
        drop = true;
    }
}

