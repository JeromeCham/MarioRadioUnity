using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isActivated = false;
    public bool onActivator = false;

    [SerializeField]
    private Vector3 doorPositionInitial = new Vector3(0f, 0f, 0f);

    [SerializeField]
    private Vector3 doorPositionFinal = new Vector3(0f, 0f, 0f);

    [SerializeField]
    private float distanceX;

    [SerializeField]
    private float distanceY;

    [SerializeField]
    private string nom;

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
        GameObject Gate = GameObject.Find(nom);
        transform.GetChild(0).gameObject.SetActive(!isActivated);
        transform.GetChild(1).gameObject.SetActive(isActivated);
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
