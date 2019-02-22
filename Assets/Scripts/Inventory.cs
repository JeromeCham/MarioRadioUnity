using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

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

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        Debug.Log("Adding " + item.name + " to inventory");
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
