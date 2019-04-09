using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorBoost : MonoBehaviour
{
    [SerializeField]
    private bool isActivated = false;

    [SerializeField]
    private bool onActivator = false;

    [SerializeField]
    private int nbActivator;

    [SerializeField]
    private string nom;

    [SerializeField]
    private float rotation = 180;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Boost = GameObject.Find(nom);
        Boost.transform.GetChild(nbActivator).gameObject.transform.GetChild(0).gameObject.SetActive(!isActivated);
        Boost.transform.GetChild(nbActivator).gameObject.transform.GetChild(1).gameObject.SetActive(isActivated);
        if (onActivator && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Start");
            isActivated = !isActivated;
            Boost.transform.GetChild(0).Rotate(0, 0, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Boost = GameObject.Find(nom);
        Boost.transform.GetChild(nbActivator).gameObject.transform.GetChild(0).gameObject.SetActive(!isActivated);
        Boost.transform.GetChild(nbActivator).gameObject.transform.GetChild(1).gameObject.SetActive(isActivated);
        if (onActivator && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Update");
            isActivated = !isActivated;
            Boost.transform.GetChild(0).Rotate(0, 0, -rotation);
        }
    }

    bool OnTriggerStay2D(Collider2D col)
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
