using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New potion", menuName = "Inventory/potion")]
[Serializable]
public class Potion : Item
{
    [SerializeField]
    private GameObject potionPrefab;

    [SerializeField]
    private GameObject potion2;

    public GameObject PotionPrefab { get => potionPrefab; set => potionPrefab = value; }
    public GameObject Potion2 { get => potion2; set => potion2 = value; }

    PlayerMovement player;

    public override void Use()
    {
        player = FindObjectOfType<PlayerMovement>();
        Debug.Log("name");
        switch (name)
        {
            case "Red potion":
                player.RedPotion();
                break;

            case "Green potion":
                player.GreenPotion();
                break;
                
            case "Blue potion":
                player.BluePotion();
                break;

            default: break;
        }
    }
}
