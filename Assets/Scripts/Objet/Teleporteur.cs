using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public Vector3 PortInitial;
    public Vector3 PortFinal;
    static float portCooldown = 2.0f;
    static float portCooldownMax = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portCooldown > 0)
        {
            portCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (portCooldown <= 0)
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            player.transform.position = PortFinal;
            portCooldown = portCooldownMax;
        }
    }
}
