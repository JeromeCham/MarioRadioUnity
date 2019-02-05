using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private BlobFollow enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = null;
        }
    }

}
