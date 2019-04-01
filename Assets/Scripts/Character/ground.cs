using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    [SerializeField]
    private GameObject pont = null;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "pont2")
        {
            pont.layer = 0;
        }
    }
}
