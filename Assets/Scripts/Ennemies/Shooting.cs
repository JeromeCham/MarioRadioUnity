using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int health = 100;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
       // Debug.Log(health);
    }
    void Die()
    {
        PlayerMovement player = GameObject.Find("Personnage").GetComponent<PlayerMovement>();
        player.addExp(10);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
