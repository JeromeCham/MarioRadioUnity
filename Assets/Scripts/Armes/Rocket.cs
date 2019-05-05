using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public bool destroy;
    public Transform ExplosionPoint;
    public GameObject ExplosionPrefab;
    public GameObject explosion;
    public float t = 0.5f;
    bool hit = false;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        if (hit == true)
        {
            Soundmanager.PlaySound("rocketshot");
            explosion = (GameObject)Instantiate(ExplosionPrefab, ExplosionPoint.position, ExplosionPoint.rotation);
            Destroy(explosion.gameObject, t);
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Dmg" || hitInfo.tag == "Gate" || hitInfo.tag == "Tilemap solid")
        {
            hit = true;
        }
    }
}



