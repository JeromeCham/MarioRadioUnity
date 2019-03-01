using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public Vector3 PortA;
    public Vector3 PortB;
    float portCooldown = 2.0f;
    bool ported = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ported == true &&  portCooldown > 0)
        {
            portCooldown -= Time.deltaTime;
        }
        else if (ported == true && portCooldown <= 0)
        {
            ported = false;
            portCooldown = 2.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();

        if (ported == false)
        {
            if (gameObject.transform.name == "Teleporteur A(1)")
            {
                player.transform.position = PortB;
                Debug.Log("TP1");
            }
            else if (gameObject.transform.position == PortB)
            {
                player.transform.position = PortA;
                Debug.Log("TP2");
            }
            ported = true;
        }
    }
}
