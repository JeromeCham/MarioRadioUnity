using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShop : MonoBehaviour
{
    public bool active = false;
    public int money = 0;
    void Update()
    {
        if (active == true && Input.GetKeyDown(KeyCode.E) && money > 0)
        {
            Weapons.instance.AddMagazine();
            money -= 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shop")
        {
            active = true;
        }
        Debug.Log(active);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Shop")
        {
            active = false;
        }
        Debug.Log(active);
    }
}