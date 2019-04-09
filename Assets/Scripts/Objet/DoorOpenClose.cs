using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Vector3 destination;
    
    void Start()
    {
        SetDestination(gameObject.transform.position);
    }

    void Update()
    {
        if (destination != gameObject.transform.position)
        {
            MoveObject(destination);
        }
    }

    public void SetDestination(Vector3 endroit)
    {
        destination = endroit;
    }

    public void MoveObject(Vector3 destination)
    {
        float dx = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, dx);

        gameObject.transform.position = nextPosition;
    }
}