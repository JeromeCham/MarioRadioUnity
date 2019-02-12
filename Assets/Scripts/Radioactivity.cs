using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactivity : MonoBehaviour
{
    public float radioMagnitude = 0.0f;  
    public float dmgTimer = 0.3f;
    public float maxTimer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dmgTimer > 0)
        {
            dmgTimer -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        float radius = (gameObject.GetComponent<Collider2D>() as CircleCollider2D).radius;
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        float proximity = Vector2.Distance(gameObject.transform.position, player.transform.position);
        float effect = 1 - (proximity / radius);
        if (effect > 0)
        {
            dmgTimer = player.takeDmg((radioMagnitude * effect), dmgTimer, maxTimer);
        }
    }
}
