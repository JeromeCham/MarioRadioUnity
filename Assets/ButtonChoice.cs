using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoice : MonoBehaviour
{
    public void choice1A()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
        player.setJumpForce(900);
    }

    public void choice2A()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
        player.Health.MaxVal = 120;
    }

    public void choice1B()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();

    }

    public void choice2B()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
    }

    public void choice1C()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
    }

    public void choice2C()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
    }
}
