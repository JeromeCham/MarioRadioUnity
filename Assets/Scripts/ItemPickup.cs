using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public BoxCollider2D collider;
    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PickUp();
        }
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
