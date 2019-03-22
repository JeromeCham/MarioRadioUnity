using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
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
            explosion = (GameObject)Instantiate(ExplosionPrefab, ExplosionPoint.position, ExplosionPoint.rotation);
            //gameObject.SetActive(false);

            Destroy(explosion.gameObject, t);
            Destroy(gameObject);
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
                enemy.TakeDamage(50);
            }

            hit = true;
        }
    }
}



