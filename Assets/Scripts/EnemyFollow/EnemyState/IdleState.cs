using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private BlobFollow enemy;

    private float idleTimer;

    private float idleDuration = 1;

    public void Enter(BlobFollow enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("I am idling");

        Idle();

        if (enemy.Target != null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void Idle()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

}
