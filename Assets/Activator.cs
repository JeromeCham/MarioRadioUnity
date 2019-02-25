using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool onOff = false;

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
    }

    bool OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onOff = !onOff;
            return onOff;
        }
        return onOff;
    }
}
