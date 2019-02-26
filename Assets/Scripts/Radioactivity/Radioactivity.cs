using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactivity : MonoBehaviour
{
    public float radioMagnitude = 0.0f;
    public float dmgCooldown = 0.3f;
    public float maxCooldown = 0.3f;

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
            float radius = (gameObject.GetComponent<Collider2D>() as CircleCollider2D).radius;
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            float proximity = Vector2.Distance(gameObject.transform.position, player.transform.position);
            float effect = 1 - (proximity / radius);
            if (effect > 0)
            {
                dmgCooldown = player.takeDmg((radioMagnitude * effect), dmgCooldown, maxCooldown, "WTF????");
            }
        }

    }
}
