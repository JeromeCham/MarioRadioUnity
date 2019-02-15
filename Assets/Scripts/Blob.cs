using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public LayerMask blobMask;
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, blobMask);



        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            facingRight = false;
        }

        //Always move forward
        /*Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;*/
        Move();

    }
    public void Move()
    {
        transform.Translate(GetDirection() * (speed * Time.deltaTime));
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
}