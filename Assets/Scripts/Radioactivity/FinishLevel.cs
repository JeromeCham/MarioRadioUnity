using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private PlayerMovement player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponentInParent<PlayerMovement>();
        //Debug.Log(player.Neutraliser.CurrentValue);
        if (other.tag == "Player" && player.Neutraliser.CurrentValue == 10 && player.Health.CurrentValue > 0)
        {
            FindObjectOfType<GameManager>().Invoke("NextLevel", 0f);
            //Debug.Log("collision");
        }
    }
}
