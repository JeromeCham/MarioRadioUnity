﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float temp = 800f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        player.setJumpForce(0);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        player.setJumpForce(temp);
    }
}