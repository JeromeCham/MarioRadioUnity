using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timeleft = 10f;
    public bool destroy;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            destroy = true;
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            player.takeDmg(5);
            Destroy(gameObject);
        }
        else
        {
            if (destroy == true)
            {
                Destroy(gameObject);
            }
        }

        if (col.tag == "Gate")
        {
            Destroy(gameObject);
        }

        if (col.tag == "Tilemap solid")
        {
            Destroy(gameObject);
        }
    }
}
