using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public bool gun = false;
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
        int index = items.FindIndex(Item => item.name == "Gun");
        if (index >= 0)
        {
            Debug.Log("allo");
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
    }
}

