﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFollow : Character
{

    private IEnemyState currentState;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
      
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();

    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(this);
    }
}
