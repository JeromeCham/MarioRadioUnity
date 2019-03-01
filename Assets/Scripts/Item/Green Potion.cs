﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New green potion", menuName = "Inventory/Green potion")]
public class GreenPotion : Item
{
    PlayerMovement player;

    override
    public bool Use()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (!player.isUsingGreenPotion && !player.isUsingBluePotion)
        {
            player.GreenPotion();
            return true;
        }
        return false;
    }
}
