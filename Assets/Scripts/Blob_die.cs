using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_die : MonoBehaviour
{
    public GameObject other2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Die");
            Destroy(other2);
        }
    }
}
