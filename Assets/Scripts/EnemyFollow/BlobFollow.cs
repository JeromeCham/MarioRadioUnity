﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFollow : Character
{
    Transform mytrans;
    private IEnemyState currentState;

    public GameObject Target { get; set; }
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
        LookAtTarget();
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

    public void Move()
    {
        transform.Translate(GetDirection() * (movementspeed * Time.deltaTime));
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }
    private void  LookAtTarget()
    {
        if(Target != null)
        {
            float xDir =  Target.transform.position.x - transform.position.x;
            
            if (xDir > 0 && facingRight || xDir < 0 &&  !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }
}
