using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New red potion", menuName = "Inventory/Red potion")]
public class Redpotion : Item
{
    PlayerMovement player;
    override
    public bool Use()
    {
        player = FindObjectOfType<PlayerMovement>();

        player.RedPotion();
        return true;
    }
}
