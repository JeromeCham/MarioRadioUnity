using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponentInParent<Inventaire>().AddMoney(10);
            Destroy(gameObject);
        }
    }
}
