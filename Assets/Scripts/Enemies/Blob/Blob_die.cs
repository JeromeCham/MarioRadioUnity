using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_die : MonoBehaviour
{
    public GameObject blob;
    public float timer;
    bool hit = false;
    public int expValue = 10;
    void Update()
    {
        if (hit == true)
        {
            timer += 1;
        }
        if (timer == 10)
        {
            Destroy(blob);
            GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().addExp(expValue);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Die");
            hit = true;
        }
    }
}