using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMouvement : MonoBehaviour
{
    [SerializeField]
    private Transform Cloud;

    [SerializeField]
    private float cloudSpeed = 0.01f;

    [SerializeField]
    float cloudPosistionX = 20f;

    void Update()
    {
        transform.Translate(Vector3.right * cloudSpeed);

        Vector3 temp = transform.position;

        if (temp.x >= cloudPosistionX)
        {
            temp.x = -cloudPosistionX;
            Cloud.transform.position = temp;
        }
    }
}
