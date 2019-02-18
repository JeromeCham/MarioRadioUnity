using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFollow : Character
{
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
        if (currentState != null)
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
        if (facingRight == true)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.left;
        }
    }
    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            //Debug.Log(message: xDir);

            //Debug.Log(GetDirection());
            if (xDir < 0 && movementspeed > 0 || xDir > 0 && movementspeed < 0)
            {
                ChangeDirection();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(other);
    }
}
