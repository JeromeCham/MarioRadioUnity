using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFollow : Character
{

    private IEnemyState currentState;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        

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
