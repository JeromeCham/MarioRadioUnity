using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isActivated = false;
    public bool onActivator = false;
    public Vector3 doorPositionInitial = new Vector3(4.35f, -3.7f, 0f);
    public Vector3 doorPositionFinal = new Vector3(4.35f, -1f, 0f);
    public string nom;

    // Start is called before the first frame update
    void Start()
    {
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
        onActivator = true;
        return onActivator;
    }

    bool OnTriggerExit2D(Collider2D col)
    {
        onActivator = false;
        return onActivator;
    }
}
