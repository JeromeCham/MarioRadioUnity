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
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        //transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

        Vector3 currRot = mytrans.eulerAngles;
        currRot.y += 180;
        mytrans.eulerAngles = currRot;
    }
}
