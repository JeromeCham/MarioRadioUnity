using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    Transform mytrans;

    [SerializeField]
    protected float movementspeed;

    protected bool facingRight;
    // Start is called before the first frame update
    public virtual void Start()
    {
        mytrans = this.transform;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirection()
    {
        movementspeed = -movementspeed;
        facingRight = !facingRight;

        Vector3 currRot = mytrans.eulerAngles;
        currRot.y += 180;
        mytrans.eulerAngles = currRot;
    }
}
