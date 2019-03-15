using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neutraliser : MonoBehaviour
{

    private PlayerMovement player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            player = other.GetComponentInParent<PlayerMovement>();
            player.neutraliser.CurrentValue += 1;
            Destroy(gameObject);
        }
    }
}
