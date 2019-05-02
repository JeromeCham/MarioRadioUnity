using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryUI:MonoBehaviour
{
    public Transform itemsParent;
    Inventaire inventory;
    public InventorySlot[] slots; 

    void Start()
    {
        inventory = Inventaire.instance;
        inventory.onItemChangedCallback += UpdateUI; 
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
