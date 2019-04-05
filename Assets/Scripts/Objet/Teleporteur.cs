﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    [SerializeField]
    private Transform positionPortal = null;
    
    private Vector3 PortFinal;

    private static float portCooldown = 2.0f;

    private static float portCooldownMax = 2.0f;
    
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
            PortFinal = positionPortal.position;

            PlayerMovement player = col.GetComponent<PlayerMovement>();
            player.transform.position = PortFinal;
            portCooldown = portCooldownMax;
        }
    }
}
