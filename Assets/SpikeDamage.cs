using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float impaleDmg = 10.0f;
    public float dmgTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (dmgTimer > 0)
        {
            dmgTimer -= Time.deltaTime;
        }*/
    }

    /*void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = col.GetComponent<Player>();
            if (dmgTimer <= 0)
            {
                player.takeDmg(impaleDmg);
                dmgTimer = 0.5f;
            }
        }
    }*/
}