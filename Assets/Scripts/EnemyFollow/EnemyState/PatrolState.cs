using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private BlobFollow enemy;

    private float patrolTimer;
    private float patrolDuration=5;

    public void Enter(BlobFollow enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Patroling");
        Patrol();

        enemy.Move();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
       if(other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
