using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    [SerializeField]
    private GameObject pont2;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "pont2")
        {
            pont2.layer = 0;
        }
    }
}
