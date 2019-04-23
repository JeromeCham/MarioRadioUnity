using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_Damage : MonoBehaviour
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

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            dmgTimer = player.takeDmg(hitDamage, dmgTimer, maxTimer, "Blob");
        }
    }
}
