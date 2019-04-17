using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_die : MonoBehaviour
{
    public GameObject other2;
    public float timer;
    bool hit = false;
    void Update()
    {
        if (hit == true)
        {
            timer += 1;
        }
        if (timer == 10)
        {
            Destroy(other2);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Die");
            hit = true;
        }
    }
}