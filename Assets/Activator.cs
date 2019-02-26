using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool onOff = false;
    public bool onActivator = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(!onOff);
        transform.GetChild(1).gameObject.SetActive(onOff);
        GameObject.Find("Gate").transform.GetChild(0).gameObject.SetActive(onOff);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(!onOff);
        transform.GetChild(1).gameObject.SetActive(onOff);
        GameObject.Find("Gate").transform.GetChild(0).gameObject.SetActive(onOff);

        if (onActivator && Input.GetKeyDown(KeyCode.E))
        {
            onOff = !onOff;
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
