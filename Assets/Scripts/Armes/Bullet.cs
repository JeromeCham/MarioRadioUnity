using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Dmg")
        {
            Debug.Log("hit");
            Shooting enemy = hitInfo.GetComponent<Shooting>();
            if (enemy != null)
            {
                enemy.TakeDamage(5);
            }
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Gate")
        {
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Tilemap solid")
        {
            Destroy(gameObject);
        }
        else
        {
            if (destroy == true)
            {
                Destroy(gameObject);
            }
        }
    }
}

