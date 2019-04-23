using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float temp = 800f;

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponentInParent<PlayerMovement>();
        if (player == null) Debug.Log("player null");
        player.setJumpForce(0);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponentInParent<PlayerMovement>();
        player.setJumpForce(temp);
    }
}
