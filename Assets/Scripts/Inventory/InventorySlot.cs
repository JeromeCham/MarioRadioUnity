using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI description;
    Item item;
    PlayerMovement player;

    public static InventorySlot instanceslot;

    private void Awake()
    {
        if (instanceslot != null)
        {
            return;
        }
        instanceslot = this;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        description.text = (item.description);
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        description.text = ("");
    }

    public void OnRemoveButton()
    {
        Inventaire.instance.Remove(item);
        Inventaire.instance.Drop(item);
    }

    public void UseItem()
    {
        player = FindObjectOfType<PlayerMovement>();

        if(item.name == "Gun" || item.name == "Machine gun" || item.name == "RocketLauncher")
        {
            Inventaire.instance.SelectWeapon(item);
        }

        if (item != null && item.name != "Gun" && item.name != "Machine gun" && item.name != "RocketLauncher")
        {
            if (item.name == "Red potion" || (!player.isUsingBluePotion && !player.isUsingGreenPotion))
            {
                item.Use();
                Inventaire.instance.Remove(item);
            }
        }
    }
}
