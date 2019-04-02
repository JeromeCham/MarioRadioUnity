using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float temp = 800f;

    void OnTriggerStay2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        player.setJumpForce(0);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        player.setJumpForce(temp);
    }
}
