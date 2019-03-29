using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float impaleDmg = 10.0f;
    public float dmgCooldown = 0.5f;
    public float maxCooldown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dmgCooldown > 0)
        {
            dmgCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            dmgCooldown = player.takeDmg(impaleDmg, dmgCooldown, maxCooldown, "Spike");
        }
    }
}
    
