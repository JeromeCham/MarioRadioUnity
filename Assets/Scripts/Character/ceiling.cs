using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceiling : MonoBehaviour
{
    [SerializeField]
    private GameObject pont = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pont")
        {
            pont.layer = 9;
        }
    }
}
