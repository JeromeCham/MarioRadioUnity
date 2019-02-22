using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMouvement : MonoBehaviour
{
    private Transform Cloud;

    private float offset;

    float cloudPosistionX = 20f;
    
    void Start()
    {
        Cloud = GameObject.FindGameObjectWithTag("Cloud").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = Cloud.transform.position.x;

        if (Cloud.transform.position.x >= cloudPosistionX)
        {
            temp.x = -cloudPosistionX;
        }
        else
        {
            //fonction qui augmente avec le temp doucement
            //temp.x = Cloud.transform.position.x;
        }

        transform.position = temp;
    }
}
