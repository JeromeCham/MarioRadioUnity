using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactivityAlpha : MonoBehaviour
{
    float dmgCooldown = 0.2f;
    float maxCooldown = 0.2f;
    float radioMagnitude = 1f;

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

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            dmgCooldown = player.takeDmg(radioMagnitude, dmgCooldown, maxCooldown, "Alpha");
        }
    }
}