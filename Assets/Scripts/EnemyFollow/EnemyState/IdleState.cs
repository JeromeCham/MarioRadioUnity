using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private BlobFollow enemy;

    private float idleTimer;

    private float idleDuration = 5;

    public void Enter(BlobFollow enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("I am idling");
        Idle();
    }

    public void Exit()
    {
       
    }

    public void OnTriggerEnter(Collider2D other)
    {
    
    }

    private void Idle()
    {
        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

}
