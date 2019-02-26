using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Close : MonoBehaviour
{
    public float speed;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        SetDestination(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != gameObject.transform.position)
        {
            MoveObject();
        }
    }

    public void SetDestination(Vector3 endroit)
    {
        destination = endroit;
    }

    public void MoveObject()
    {
        float dx = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, dx);

        gameObject.transform.position = nextPosition;
    }
}