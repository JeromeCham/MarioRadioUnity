using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint = null;

    [SerializeField]
    private BlobFollow enemy = null;

    [SerializeField]
    private Arme blobgun = null;

    private bool shoot = false;

    private float countdown = 0f;

    void Update()
    {
        if (shoot == true && countdown > 20)
        {
            Shot();
        }

        countdown += 1;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;
            shoot = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shoot = false;
            enemy.Target = null;
        }
    }
    void Shot()
    {
        blobgun.Bullet = (GameObject)Instantiate(blobgun.BulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(blobgun.Bullet, blobgun.BulletLife);
        countdown = 0;
    }
}


