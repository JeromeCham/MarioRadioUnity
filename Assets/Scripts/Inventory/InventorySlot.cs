
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        Inventory.instance.Drop(item);
    }

    public void UseItem()
    {
        if(item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
            Inventory.instance.SelectWeapon(item);
        }

        if (item != null && item.Use() && item.name != "Gun" && item.name != "Machine gun" && item.name != "RocketLauncher")
        {
            item.Use();
            Inventory.instance.Remove(item);
        }
    }
}
