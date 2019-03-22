using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceiling : CharacterController2D
{
    [SerializeField]
    private Collider2D pont;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pont")
        {
            pont.isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "pont")
        {
            pont.isTrigger = false;
        }
    }
}
