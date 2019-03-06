using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New blue potion", menuName = "Inventory/Blue potion")]
public class BluePotion : Item
{
    PlayerMovement player;

    override
    public bool Use()
    {
        Debug.Log("Using " + name);
        player = FindObjectOfType<PlayerMovement>();
        if (!player.isUsingGreenPotion && !player.isUsingBluePotion)
        {
            player.BluePotion();
            return true;
        }
        return false;
    }
    /*override
   public bool Use()
    {
        Debug.Log("Using " + name);
        player = FindObjectOfType<PlayerMovement>();

        player.BluePotion();
        return true;
    }*/

}
