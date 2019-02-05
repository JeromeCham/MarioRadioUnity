using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState
{
    private BlobFollow enemy;

    public void Enter(BlobFollow enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if(enemy.Target !=null)
        {
            enemy.Move();
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }
}
