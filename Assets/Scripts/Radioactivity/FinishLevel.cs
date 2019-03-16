using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private PlayerMovement player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponentInParent<PlayerMovement>();

        if (other.tag == "Player" && player.neutraliser.CurrentValue == 10)
        {
            FindObjectOfType<GameManager>().NextLevel();
            Debug.Log("collision");
        }
    }
}
