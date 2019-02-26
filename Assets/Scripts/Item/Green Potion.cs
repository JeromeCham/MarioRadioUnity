using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New green potion", menuName = "Inventory/Green potion")]
public class GreenPotion : Item
{
    PlayerMovement player;

    override
    public void Use()
    {
        player = FindObjectOfType<PlayerMovement>();

        player.GreenPotion();
    }
}
