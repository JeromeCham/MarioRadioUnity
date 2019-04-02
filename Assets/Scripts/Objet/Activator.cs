using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isActivated = false;
    public bool onActivator = false;
    private Vector3 doorPositionInitial;
    private Vector3 doorPositionFinal;
    public string nom;
    public float distanceX;
    public float distanceY;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Gate = GameObject.Find(nom);
        doorPositionInitial = Gate.transform.GetChild(0).position;
        doorPositionFinal = new Vector3(doorPositionInitial.x + distanceX, doorPositionInitial.y + distanceY, doorPositionInitial.z);
        transform.GetChild(0).gameObject.SetActive(!isActivated);
        transform.GetChild(1).gameObject.SetActive(isActivated);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(!isActivated);
        transform.GetChild(1).gameObject.SetActive(isActivated);
        GameObject Gate = GameObject.Find(nom);
        DoorOpenClose gate1 = Gate.transform.GetChild(0).GetComponent<DoorOpenClose>();

        if (onActivator && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = !isActivated;
            if (isActivated == true)
            {
                gate1.SetDestination(doorPositionFinal);
            }
            else
            {
                gate1.SetDestination(doorPositionInitial);
            }
        }
    }

    bool OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            onActivator = true;
            return onActivator;
        }
        return onActivator;
    }

    bool OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            onActivator = false;
            return onActivator;
        }
        return onActivator;
    }
}
