using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSelfDmg : MonoBehaviour
{
    public float hitDamage = 0.0f;
    public float dmgTimer = 0.3f;
    public float maxTimer = 0.3f;

    void Update()
    {
        if (dmgTimer > 0)
        {
            dmgTimer -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Dmg")
        {
            Shooting enemy = other.GetComponent<Shooting>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
            }
        }
        if (other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            dmgTimer = player.takeDmg(hitDamage, dmgTimer, maxTimer, "Blob");
        }

    }
}
